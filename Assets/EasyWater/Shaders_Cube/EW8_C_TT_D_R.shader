// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "EWater/Reflective/EW8_C_TT_D_R"
{
	Properties 
	{
_Color("_Color", Color) = (1,1,1,1)
_Texture1("_Texture1", 2D) = "black" {}
_Texture2("_Texture2", 2D) = "black" {}
_DistortionMap1("_DistortionMap1", 2D) = "black" {}
_DistortionMap2("_DistortionMap2", 2D) = "black" {}
_DistortionPower("_DistortionPower", Range(0,0.02) ) = 0
_Reflection("_Reflection", Cube) = "black" {}
_ReflectPower("_ReflectPower", Range(0,1) ) = 0

	}
	
	SubShader 
	{
		Tags
		{
			"Queue"="Transparent-1"
			"IgnoreProjector"="False"
			"RenderType"="Transparent"
		}

		
		Cull Back
		ZWrite On
		ZTest LEqual
		ColorMask RGBA
		Blend SrcAlpha OneMinusSrcAlpha
		Fog{
		}
		
		
		CGPROGRAM
		#pragma surface surf WetSpecular
		#pragma target 2.0
		
		
		fixed4 _Color;
		uniform sampler2D _Texture1;
		uniform sampler2D _Texture2;
		uniform sampler2D _DistortionMap1;
		uniform sampler2D _DistortionMap2;
		half _DistortionPower;
		

		half4 LightingWetSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
          half3 h = normalize (lightDir + viewDir);
          half diff = max (0, dot (s.Normal, lightDir));
          float nh = max (0, dot (s.Normal, h));
          float spec = pow (nh, s.Specular*128.0)* s.Gloss;
          half4 c;
          c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * (atten * 2);
          c.a = s.Alpha;
          return c;
      }
				
		
		struct Input {
			float3 viewDir : TEXCOORD4;
			float2 uv_Texture1;
			float2 uv_Texture2;
			float2 uv_DistortionMap1;
			float2 uv_DistortionMap2;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
			
			
			float2 DistortUV=(IN.uv_DistortionMap1.xy);
			float4 DistortNormal = tex2D(_DistortionMap1,DistortUV);
			// Multiply Tex2DNormal effect by DistortionPower
			float2 FinalDistortion = DistortNormal * _DistortionPower;
			
			
			
			float2 MainTexUV=(IN.uv_Texture1.xy);			
			// Apply Distorion in MainTex
			float4 DistortedMainTex=tex2D(_Texture1,MainTexUV + FinalDistortion);
			
			
			
			float2 Tex2UV=(IN.uv_Texture2.xy);			
			// Apply Distorion in Texture2
			float4 DistortedTexture2=tex2D(_Texture2,Tex2UV + FinalDistortion); 
			
			// Merge MainTex and Texture2
			float4 TextureMix=DistortedMainTex * DistortedTexture2;
			
			
			// Merge Textures, Texture and Color
			float4 FinalDiffuse = _Color * TextureMix; 			
			
			
			// Animate DistortionMap1
			float2 Bump1UV=(IN.uv_DistortionMap1.xy) ;
			
			// Apply Distortion to BumpMap
			half4 DistortedDistortionMap1=tex2D(_DistortionMap1,Bump1UV + FinalDistortion);			
			
			half2 Bump2UV=(IN.uv_DistortionMap2.xy);
			
			// Apply Distortion to DistortionMap2			
			fixed4 DistortedDistortionMap2=tex2D(_DistortionMap2,Bump2UV + FinalDistortion);
			
			// Get Average from DistortionMap1 and DistortionMap2
			fixed4 AvgBump= (DistortedDistortionMap1 + DistortedDistortionMap2) / 2;
			
			// Unpack Normals
			fixed4 UnpackNormal1=float4(UnpackNormal(AvgBump).xyz, 1.0);
			
			
				
			o.Albedo = FinalDiffuse;
			o.Normal = UnpackNormal1;
			o.Alpha = 1;

			o.Normal = normalize(o.Normal);
		}
	ENDCG

Pass{
            Tags {
                "Queue"="Transparent"  "RenderType" = "Transparent" }
Blend  SrcAlpha OneMinusSrcAlpha

CGPROGRAM

        #pragma vertex vert
        #pragma fragment frag alpha
        #include "UnityCG.cginc" 

        uniform float4x4 _ProjMatrix;
            samplerCUBE _Reflection;
            float _ReflectPower;
            uniform sampler2D _DistortionMap1;
            uniform sampler2D _DistortionMap2;
            float4 _DistortionMap1_ST;
            float4 _DistortionMap2_ST;
            fixed _DistortionPower;
            


            struct v2f {
                float4 pos : POSITION;
                float2 distortUV : TEXCOORD2;
                float2 distort2UV : TEXCOORD3;
                float3 I : TEXCOORD1;
                float3 viewDir : TEXCOORD4;
            }; 

            v2f vert( appdata_tan v ) {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                o.distortUV = TRANSFORM_TEX (v.texcoord, _DistortionMap1);
                
                o.distort2UV = TRANSFORM_TEX (v.texcoord, _DistortionMap2);
                // calculate object space reflection vector	
			   o.viewDir = ObjSpaceViewDir( v.vertex );
                float3 I = reflect( -o.viewDir, v.normal );
                // transform to world space reflection vector
			o.I = mul( (float3x3)unity_ObjectToWorld, I );  
                return o;
            }

        
        half4 frag( v2f IN ) : COLOR {
        		
        		float4 DistortNormal =  tex2D(_DistortionMap1,IN.distortUV * 10 ); 
        		float4 DistortNormal2 =  tex2D(_DistortionMap2,IN.distort2UV  * 10); 
        		float FinalDistortion = (DistortNormal.x - DistortNormal2.x) * _DistortionPower * 50;
                
                half4 reflection = texCUBE( _Reflection, IN.I +  FinalDistortion); 
                
                half4 final = reflection ;
                
                //float Fresnel0=(1.0 - dot( normalize( float3( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z ).xyz), normalize( float3(0,0,1) ) ));
			
                final.a =  _ReflectPower ; 
                return final; 
            }   
        ENDCG
}
	

	}
	Fallback "Diffuse"
}