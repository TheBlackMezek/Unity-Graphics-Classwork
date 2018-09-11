Shader "Custom/SpecularForwardAdd"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BumpMap("Normal", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Ambient("Ambient", Range(0,1)) = 0.25
		_SpecColor("Specular Color", color) = (1,1,1,1)
		_Shininess("Shininess", float) = 10
	}
	SubShader
	{
		//LOD 100

		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			#pragma multi_compile_fwdbase
			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;

				float4 vertexClip : SV_POSITION;
				float4 vertexWorld : TEXCOORD1;
				//float3 worldNormal : TEXCOORD2;

				half3 tspace0 : TEXCOORD2;
				half3 tspace1 : TEXCOORD3;
				half3 tspace2 : TEXCOORD4;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _BumpMap;
			float4 _BumpMap_ST;

			float4 _Color;
			float _Ambient;
			float _Shininess;


			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertexClip = UnityObjectToClipPos(v.vertex);
				o.vertexWorld = mul(unity_ObjectToWorld, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				float3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBitangent = cross(worldNormal, worldTangent) * tangentSign;

				o.tspace0 = half3(worldTangent.x, worldBitangent.x, worldNormal.x);
				o.tspace1 = half3(worldTangent.y, worldBitangent.y, worldNormal.y);
				o.tspace2 = half3(worldTangent.z, worldBitangent.z, worldNormal.z);

				UNITY_TRANSFER_FOG(o,o.vertex);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				//return float4(0,1,0,1);
				float4 albedoCol = tex2D(_MainTex, i.uv);
				//Normal calculation
				half3 tNormal = UnpackNormal(tex2D(_BumpMap, i.uv));
				half3 worldNormal;
				worldNormal.x = dot(i.tspace0, tNormal);
				worldNormal.y = dot(i.tspace1, tNormal);
				worldNormal.z = dot(i.tspace2, tNormal);

				float3 normalDir = normalize(worldNormal);
				float3 viewDir = normalize(UnityWorldSpaceViewDir(i.vertexWorld));
				float3 lightDir = normalize(UnityWorldSpaceLightDir(i.vertexWorld));
				//Directional light
				float nl = max(_Ambient, dot(normalDir, lightDir));
				float4 diffuseTerm = nl * (albedoCol * _Color) * _LightColor0;
				//Specular
				float3 reflectionDir = reflect(-lightDir, normalDir);
				float3 specularDot = max(0.0, dot(viewDir, reflectionDir));
				float3 specular = pow(specularDot, _Shininess);
				float4 specularTerm = float4(specular, 1) * _SpecColor * _LightColor0;

				float4 finalCol = diffuseTerm * specularTerm;

				//UNITY_APPLY_FOG(i.fogCoord, col);

				return finalCol;
			}
			ENDCG
		}
		Pass
		{
			Tags {"LightMode" = "ForwardAdd"}
			Blend One One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			#pragma multi_compile_fwdadd
			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;

				float4 vertexClip : SV_POSITION;
				float4 vertexWorld : TEXCOORD1;
				//float3 worldNormal : TEXCOORD2;

				half3 tspace0 : TEXCOORD2;
				half3 tspace1 : TEXCOORD3;
				half3 tspace2 : TEXCOORD4;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _BumpMap;
			float4 _BumpMap_ST;

			float4 _Color;
			float _Ambient;
			float _Shininess;



			v2f vert(appdata v)
			{
				v2f o;
				o.vertexClip = UnityObjectToClipPos(v.vertex);
				o.vertexWorld = mul(unity_ObjectToWorld, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				float3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBitangent = cross(worldNormal, worldTangent) * tangentSign;

				o.tspace0 = half3(worldTangent.x, worldBitangent.x, worldNormal.x);
				o.tspace1 = half3(worldTangent.y, worldBitangent.y, worldNormal.y);
				o.tspace2 = half3(worldTangent.z, worldBitangent.z, worldNormal.z);

				UNITY_TRANSFER_FOG(o,o.vertex);

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//return float4(0,0,0,1);
				float4 albedoCol = tex2D(_MainTex, i.uv);
				//Normal calculation
				half3 tNormal = UnpackNormal(tex2D(_BumpMap, i.uv));
				half3 worldNormal;
				worldNormal.x = dot(i.tspace0, tNormal);
				worldNormal.y = dot(i.tspace1, tNormal);
				worldNormal.z = dot(i.tspace2, tNormal);

				float3 normalDir = normalize(worldNormal);
				float3 viewDir = normalize(UnityWorldSpaceViewDir(i.vertexWorld));
				float3 lightDir = normalize(UnityWorldSpaceLightDir(i.vertexWorld));
				//Directional light
				float nl = max(0.0, dot(normalDir, lightDir));
				float4 diffuseTerm = nl * (albedoCol * _Color) * _LightColor0;
				//Specular
				float3 reflectionDir = reflect(-lightDir, normalDir);
				float3 specularDot = max(0.0, dot(viewDir, reflectionDir));
				float3 specular = pow(specularDot, _Shininess);
				float4 specularTerm = float4(specular, 1) * _SpecColor * _LightColor0;

				float4 finalCol = diffuseTerm * specularTerm;

				//UNITY_APPLY_FOG(i.fogCoord, col);

				return finalCol;
			}
			ENDCG
		}
	}
}
