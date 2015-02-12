Shader "Custom/NewShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainColor ("Main Color", Color) = (1, 1, 1, 1)
		_LightPower("Light Power", Range(0, 1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf MyLightModel

		sampler2D _MainTex;
		float4 _MainColor;
		half   _LightPower;

		struct Input {
			float2 uv_MainTex;
		};
		
		fixed4 LightingMyLightModel(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
		{
			half4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = _MainColor.rgb;
			o.Alpha = _MainColor.a;
			o.Emission = _LightPower;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
