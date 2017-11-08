Shader "Portal/WarpEffect" 
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_portalCenter("Portal Center Point", Vector) = (0,0,0)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float3 _portalCenter;

			float4 frag(v2f_img i) : COLOR
			{
				float4 c = tex2D(_MainTex, i.uv);

				float distMult =  1 - dot(_portalCenter, _portalCenter) * 0.1f;

				float2 diff = i.uv - _portalCenter.xy;

				float dotVal = dot(diff,diff) * 0.5f;

				float4 o = c;
				o.rgb = lerp(c.rgb, float3(1.0f,1.0f,1.0f), dotVal*distMult);

				return o;
			}
			ENDCG

		}
	}

}
