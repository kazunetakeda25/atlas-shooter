// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Caustics" {
   Properties {
      _Caustics ("Caustics Image", 2D) = "white" {}
      _Speed("_Speed", Float) = 1
      _Intensity("_Intensity", Float) = 1
      _Tile("_Tile", Float) = 5
   }
   SubShader {
 
      Pass { 
      ZWrite off
        Fog { Color (0, 0, 0) } 
      
        
         Blend One One    
            // add color of _Caustics to the color in the framebuffer 
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag  ShadowCaster
 
         // User-specified properties
         uniform sampler2D _Caustics; 
         float _Speed;
         //float _Time; 
         float _Intensity;
         float _Tile;
 
         // Projector-specific uniforms
         uniform float4x4 unity_Projector; // transformation matrix 
            // from object space to projector space 
 
          struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 posProj : TEXCOORD0;
            // position in projector space
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            output.posProj = mul(unity_Projector, input.vertex);
            output.pos = UnityObjectToClipPos(input.vertex);
            return output;
         }
 
 
         float4 frag(vertexOutput input) : COLOR
         {
         	float texPos = _Speed * _Time;
            
            float4 tex1 = tex2D(_Caustics ,(float2(input.posProj.xy) * _Tile / input.posProj.w)+texPos); 

            float4 tex2 = tex2D(_Caustics , (float2(input.posProj.x, input.posProj.y+ (2.5 * _Tile)) *_Tile/ input.posProj.w)-texPos  ); 
            
           

                        
            float4 finalTex =  (tex1 * tex2) * _Intensity; 
			// Replace above line with the following for a slightly different effect:
			//float4 finalTex = (tex1 * tex2) * (tex1 * tex2) * _Intensity;   
           
             return finalTex;
            
         }
 
         ENDCG
      }
      }  
   }