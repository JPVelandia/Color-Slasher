Shader "Unlit/Dissolve3"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_NoiseTexture("NoiseTex",2D) = "white"{}
		_DissolveAmount("Dissolving", Range(0,1)) = 0
	}
		SubShader
		{
			Tags { "RenderType" = "TransparentCutout"
					 "Queque" = "Transparent"
					}
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _NoiseTexture;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_NoiseTexture;
			};

			fixed4 _Color;
			float _DissolveAmount = 0;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				//Remap recibes time
				//if Remap is = 0, add 0.01 
				//with resulto, go from 0 to 1 cheking ">" for every pixel.
				//multiply by 2 and then multiply the Color

				float b = tex2D(_NoiseTexture, IN.uv_NoiseTexture);
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

				/*if (_IsDissolving == 1)
				{
					_DissolveAmount = ((sin(_Time.y)) * 0.5) + 0.5;
				}*/

				float Step = 0;

				if (_DissolveAmount + 0.01 > b)
				{
					Step = 1;
				}

				float3 mult = _Color * Step;

				if (b < _DissolveAmount)
				{
					discard;
				}

				o.Emission = mult;
				o.Alpha = b;
				o.Albedo = c.rgb;
			}
            ENDCG
        }
}
