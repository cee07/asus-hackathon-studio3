// Simplified Bumped shader. Differences from regular Bumped one:
// - no Main Color
// - Normalmap uses Tiling/Offset of the Base texture
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Mobile/Bumped Diffuse HSVA" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	
	_HSVRangeMin ("HSV Affect Range Min", Range(0, 1)) = 0
    _HSVRangeMax ("HSV Affect Range Max", Range(0, 1)) = 1
    _HSVAAdjust ("HSVA Adjust", Vector) = (0, 0, 0, 0)
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 250

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _MainTex;
sampler2D _BumpMap;
float _HSVRangeMin;
float _HSVRangeMax;
float4 _HSVAAdjust;
            
struct Input {
	float2 uv_MainTex;
};

float3 rgb2hsv(float3 c) {
  float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
  float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
  float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

  float d = q.x - min(q.w, q.y);
  float e = 1.0e-10;
  return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
}

float3 hsv2rgb(float3 c) {
  c = float3(c.x, clamp(c.yz, 0.0, 1.0));
  float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
  float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
  return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

    float3 hsv = rgb2hsv(c.rgb);
    float affectMult = step(_HSVRangeMin, hsv.r) * step(hsv.r, _HSVRangeMax);
    float3 rgb = hsv2rgb(hsv + _HSVAAdjust.xyz * affectMult);
    float4 coltarget = float4(rgb, c.a + _HSVAAdjust.a);
	o.Albedo = coltarget;
	o.Alpha = c.a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
}
ENDCG  
}

FallBack "Mobile/Diffuse"
}
