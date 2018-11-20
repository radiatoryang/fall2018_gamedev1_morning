
// declaring the name of the shader as it'll appear in Unity
Shader "Robert's Shaders/MyFirstWaterShader"
 {
	Properties // like the "public variables" in your C# scripts
	{
	    // declaring a "texture" variable, with default value of "white"
		_MainTex ("Texture", 2D) = "white" {}
		
		// declaring more "public variables" to tune this shader
		_WaveHeight ("Wave Height (Amplitude)", Float) = 0.5
		_WaveFreq ("Wave Frequency", Float) = 2.0
	}
	SubShader // where you put your shader code
	{
		Tags { "RenderType"="Opaque" } // control how it will be rendered?
		LOD 100 // "level of detail" = use less detailed visuals if it's far away?

        // each "pass" is like one instance of an Update() loop
		Pass
		{   // "CGPROGRAM" marks the start of "CG" code (HLSL used to be called "CG")
			CGPROGRAM
			// "pragma" means "compiler directive", configuring a variable or a setting
			#pragma vertex vert 
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

            // declaring some variables
			sampler2D _MainTex; // declaring a texture variable
			float4 _MainTex_ST; // declaring a "Vector4" type of variable that uses floats
			
			// every public "Property" needs a "twin" declared in the CG code
			float _WaveHeight;
			float _WaveFreq;
			
			// vertex program; where we edit the "shape" of the model
			v2f vert (appdata v)
			{
				v2f o; // here, "o" might mean "output"
				
				// add a sine wave offset to the vertex position
				v.vertex += float4(
			        0,
			        sin( (_Time.y + v.vertex.x + v.vertex.z) * _WaveFreq) * _WaveHeight, // "_Time" is the HLSL version of "Time.time"
			        0,
			        0
			    );
			    
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			// fragment shader fills-in all the pixels / adds color and texture
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.x, _Time.x) );
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
