Shader "EWater/EasyWaterFastest" {
Properties {
	_Texture1 ("Texture1", 2D) = "white" {}	
	_Opacity("_Opacity", Range(-0.1,1.0) ) = 0
}
SubShader {
	Tags { 
	"Queue"="Transparent"
	"RenderType"="Overlay" }
	LOD 150

Blend SrcAlpha OneMinusSrcAlpha

CGPROGRAM
#pragma surface surf Lambert noforwardadd



sampler2D _Texture1;
float _Opacity;

struct Input {
	float2 uv_Texture1;	
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_Texture1, IN.uv_Texture1);
	o.Albedo = c.rgb;
	o.Alpha = _Opacity;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
