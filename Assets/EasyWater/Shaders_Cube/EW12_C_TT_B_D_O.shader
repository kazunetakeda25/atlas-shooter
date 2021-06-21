Shader "EWater/EW12_C_TT_B_D_O"
{
	Properties 
	{
_Color("_Color", Color) = (1,1,1,1)
_Texture1("_Texture1", 2D) = "black" {}
_BumpMap1("_BumpMap1", 2D) = "black" {}
_Texture2("_Texture2", 2D) = "black" {}
_BumpMap2("_BumpMap2", 2D) = "black" {}
_DistortionMap("_DistortionMap", 2D) = "black" {}
_DistortionPower("_DistortionPower", Range(0,0.02) ) = 0
_Specular("_Specular", Range(0,7) ) = 1
_Gloss("_Gloss", Range(0.3,10) ) = 0.3
_Opacity("_Opacity", Range(-0.1,1.0) ) = 0

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
		uniform sampler2D _BumpMap1;
		uniform sampler2D _Texture2;
		uniform sampler2D _BumpMap2;
		uniform sampler2D _DistortionMap;
		half _DistortionPower;
		fixed _Specular;
		fixed _Gloss;
		float _Opacity;
		

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
			float2 uv_DistortionMap;
			float2 uv_Texture1;
			float2 uv_Texture2;
			float2 uv_BumpMap1;
			float2 uv_BumpMap2;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
			
			float2 DistortUV=(IN.uv_DistortionMap.xy);
			float4 DistortNormal = tex2D(_DistortionMap,DistortUV);
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
			
			
			// Animate BumpMap1
			float2 Bump1UV=(IN.uv_BumpMap1.xy) ;
			
			// Apply Distortion to BumpMap
			half4 DistortedBumpMap1=tex2D(_BumpMap1,Bump1UV + FinalDistortion);			
			
			half2 Bump2UV=(IN.uv_BumpMap2.xy);
			
			// Apply Distortion to BumpMap2			
			fixed4 DistortedBumpMap2=tex2D(_BumpMap2,Bump2UV + FinalDistortion);
			
			// Get Average from BumpMap1 and BumpMap2
			fixed4 AvgBump= (DistortedBumpMap1 + DistortedBumpMap2) / 2;
			
			// Unpack Normals
			fixed4 UnpackNormal1=float4(UnpackNormal(AvgBump).xyz, 1.0);
			
			
			
			fixed FinalAlpha = _Opacity;			
			o.Albedo = FinalDiffuse;
			o.Normal = UnpackNormal1;
			//o.Emission = FinalReflex;
			o.Specular = _Gloss;
			o.Gloss = _Specular;
			o.Alpha = FinalAlpha;

			o.Normal = normalize(o.Normal);
		}
	ENDCG


	

	}
	Fallback "Diffuse"
}