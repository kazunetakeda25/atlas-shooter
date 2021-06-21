Shader "EWater/EW2_C_T_D"
{
	Properties 
	{
_Color("_Color", Color) = (1,1,1,1)
_Texture1("_Texture1", 2D) = "black" {}
_DistortionMap1("_DistortionMap1", 2D) = "black" {}
_DistortionMap2("_DistortionMap2", 2D) = "black" {}
_DistortionPower("_DistortionPower", Range(0,0.02) ) = 0

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
			float3 viewDir;
			float2 uv_Texture1;
			float2 uv_DistortionMap1;
			float2 uv_DistortionMap2;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
			float2 DistortUV=(IN.uv_DistortionMap1.xy);
			// Create Normal for DistorionMap
			float4 DistortNormal = tex2D(_DistortionMap1,DistortUV);
			float2 FinalDistortion = DistortNormal * _DistortionPower;
			
			
			
			float2 MainTexUV=(IN.uv_Texture1.xy);			
			// Apply Distorion in MainTex
			float4 FinalDiffuse=tex2D(_Texture1,MainTexUV + FinalDistortion) * _Color;
			
			
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


	

	}
	Fallback "Diffuse"
}