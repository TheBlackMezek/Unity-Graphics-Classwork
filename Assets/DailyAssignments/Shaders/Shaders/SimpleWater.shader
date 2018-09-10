

Shader "Custom/SimpleWater" {
	Properties {
		_Tess("Tessellation", Range(1,34)) = 1
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormalMap("Normal", 2D) = "white" {}
		_NormalMap2("Normal2", 2D) = "white" {}
		_Shininess("Smoothness", Range(0,1)) = 0.5
		_SpecColor("Specular Color", color) = (1,1,1,1)
		//_Metallic ("Metallic", Range(0,1)) = 0.0

		_WaveSpeed ("Wave Speed", float) = 30
		_WaveAmp ("Wave Amplitude", float) = 1
		_NoiseTex ("Noise Tex", 2D) = "white" {}
		_TexMoveSpeed ("Tex Move Speed & Dir", vector) = (0,0,0,0)
		_TexMoveSpeed2("Tex2 Move Speed & Dir", vector) = (0,0,0,0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf BlinnPhong fullforwardshadows vertex:vert tessellate:tessFixed

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NormalMap;
		sampler2D _NormalMap2;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalMap2;
		};

		half _Shininess;
		//half _Metallic;
		fixed4 _Color;

		float _WaveSpeed;
		float _WaveAmp;
		sampler2D _NoiseTex;
		float4 _TexMoveSpeed;
		float4 _TexMoveSpeed2;



		uniform float _Tess;
		float4 tessFixed()
		{
			return _Tess;
		}

		void vert(inout appdata_full v)
		{
			float noiseSample = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0));
			v.vertex.y += sin(_Time * _WaveSpeed * noiseSample) * _WaveAmp;
			v.normal.y += sin(_Time * _WaveSpeed * noiseSample) * _WaveAmp;
		}

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {

			float2 uv = IN.uv_MainTex;
			uv += _Time.x * _TexMoveSpeed.xy;

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, uv) * _Color;
			o.Albedo = c.rgb;

			float3 normal = UnpackNormal(tex2D(_NormalMap, uv));

			float2 uv2 = IN.uv_NormalMap2;
			uv2 += _Time.x * _TexMoveSpeed2.xy;
			float3 normal2 = UnpackNormal(tex2D(_NormalMap2, uv2));

			o.Normal = (normal + normal2) / 2;

			// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic;
			o.Specular = _Shininess;
			o.Gloss = c.a;
			o.Alpha = 1.0;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
