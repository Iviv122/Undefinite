Shader "Unlit/Transition"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Size ("Size", float) = 1
        _FrontCutoff ("FrontCutoff", Range(0,1)) = 1
        _BackCutoff ("BackCutoff",Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        LOD 100


        Cull Off ZWrite Off ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha


        Pass
        {
            CGPROGRAM
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Size;
            float _FrontCutoff;
            float _BackCutoff;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 pos = i.uv;
                pos.x = floor((pos.x + _Time) / _Size);
                pos.y = floor((pos.y + _Time) / _Size);

                float PatternMask = fmod(pos.x + fmod(pos.y, 2.0), 2.0);

                float visible = step(i.uv.x, _FrontCutoff)*step(_BackCutoff, i.uv.x);

                fixed3 col = fixed3(PatternMask * fixed3(1, 1, 1));

                return fixed4(col, visible);
            }
            ENDCG
        }
    }
}
