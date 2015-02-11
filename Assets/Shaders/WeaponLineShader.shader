Shader "Custom/WeaponLineShader" {
	Properties {
		_MainColor ("Base Color (RGB)", Color) = (1.0, 1.0, 1.0, 1.0)
		_Emission1 ("Color Emission1", Range(0, 1.0)) = 1.0
		_Emission2 ("Color Emission2", Range(0, 1.0)) = 1.0
		_Emission3 ("Color Emission3", Range(0, 1.0)) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		float4 _MainColor;
		float _Emission1;
		float _Emission2;
		float _Emission3;

		struct Input {
			float2 _unused;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
			o.Albedo = _MainColor;
			o.Alpha = 1.0f;
			o.Emission = _MainColor;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
