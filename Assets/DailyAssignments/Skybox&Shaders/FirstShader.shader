
Shader "Custom/FirstShader"
{

	SubShader
	{

		Pass
		{
			CGPROGRAM

			#pragma vertex VertProg
			#pragma fragment FragProg

			#include "UnityCG.cginc"

			float4 VertProg() : SV_POSITION
			{
				return 0;
			}

			float4 FragProg(float4 position : SV_POSITION) : SV_TARGET
			{
				return 0;
			}

			ENDCG
		}
	}
}