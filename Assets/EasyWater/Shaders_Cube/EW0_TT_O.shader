Shader "EWater/EW0_TT_O"
{
	Properties 
	{
_Texture1("_Texture1", 2D) = "black" {}
_Texture2("_Texture2", 2D) = "black" {}
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
		
		
		uniform sampler2D _Texture1;
		uniform sampler2D _Texture2;
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
			float3 viewDir;
			float2 uv_Texture1;
			float2 uv_Texture2;
		};

			void surf (Input IN, inout SurfaceOutput o) {
			
			
			
			float2 MainTexUV=(IN.uv_Texture1.xy);	
			float4 MainTex=tex2D(_Texture1,MainTexUV);
			
			float2 Tex2UV=(IN.uv_Texture2.xy);
			float4 Texture2=tex2D(_Texture2,Tex2UV); 
			
			// Merge MainTex and Texture2
			float4 FinalDiffuse= MainTex * Texture2;
			
			
			// Opacity		
			o.Albedo = FinalDiffuse; 
			o.Alpha = _Opacity;
			
		}
	ENDCG


	

	}
	Fallback "Diffuse"
}