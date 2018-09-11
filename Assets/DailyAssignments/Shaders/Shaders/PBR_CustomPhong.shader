

Shader "Custom/PBR_CustomPhong" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo 1 (RGB)", 2D) = "white" {}
		_NormalMap("Normal 1", 2D) = "white" {}
		_MainTex2 ("Albedo 2 (RGB)", 2D) = "white" {}
		_NormalMap2("Normal 2", 2D) = "white" {}
		_Shininess ("Smoothness", Range(0.3,1)) = 0.5
		_SpecColor ("Specular Color", color) = (1,1,1,1)
		_AlbedoLerp ("Lerp val", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Phong fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainTex2;
		sampler2D _NormalMap;
		sampler2D _NormalMap2;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex2;
		};

		half _Shininess;
		half _AlbedoLerp;
		fixed4 _Color;



		inline void LightingPhong_GI(SurfaceOutput s, UnityGIInput data, UnityGI gi)
		{
			gi = UnityGlobalIllumination(data, 1.0, s.Normal);
		}

		inline fixed4 LightingPhong(SurfaceOutput s, half3 viewDir, UnityGI gi)
		{
			const float PI = 3.14159265;

			UnityLight light = gi.light;
			float nl = max(0.0, dot(s.Normal, light.dir)); //Angle that the light hits the normal
			float3 diffuseTerm = nl * s.Albedo.rgb * light.color; //Blending the color of the light and our albedo based on nl
			
			float norm = (_Shininess + 2) / (2 * PI);
			
			float3 reflectionDirection = reflect(-light.dir, s.Normal); //Lights always bounce opposite of what they hit
			float3 specularDot = max(0.0, dot(viewDir, reflectionDirection)); //How much specular based on reflection
			float3 specular = norm * pow(specularDot, _Shininess); //Increase specular
			float3 specularTerm = specular * _SpecColor.rgb * light.color.rgb; //Combining specular color with light color
			float3 finalColor = diffuseTerm.rgb + specularTerm.rgb; //Specular is always additive color
			
			fixed4 c;
			c.rgb = finalColor;
			c.a = s.Alpha;
#ifdef UNITY_LIGHT_FUNCTION_APPLY_INDIRECT
			c.rgb += s.Albedo + gi.indirect.diffuse;
#endif
			return c;
		}


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 c2 = tex2D (_MainTex2, IN.uv_MainTex2);
			fixed4 col = lerp(c, c2, _AlbedoLerp) * _Color;
			o.Albedo = col.rgb;

			float4 n1 = tex2D(_NormalMap, IN.uv_MainTex);
			float4 n2 = tex2D(_NormalMap2, IN.uv_MainTex2);
			float4 trueN = lerp(n1, n2, _AlbedoLerp);

			float3 normal = UnpackNormal(trueN);
			//float3 normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
			o.Normal = normal;

			// Metallic and smoothness come from slider variables
			o.Specular = _Shininess;
			o.Gloss = col.a;
			o.Alpha = 1.0;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
