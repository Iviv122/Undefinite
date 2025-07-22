Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Strength ("Strength", Range(0, 1.)) = 0.5
        _Speed ("Speed", Range(0, 10.)) = 0.5
        _Angle ("Angle", Range(0, 360.)) = 0
        _Scale ("Scale", Range(0.1, 20)) = 0
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
                fixed4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                fixed4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            fixed4 _MainTex_ST;
            float _Angle;
            float _Speed;
            float _Strength;
            float _Scale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                //fixed4 col = fixed4(0, 1, 0, 1);
                //fixed4 col = fixed4(i.uv.y, i.uv.x, 0, 1);

                float hue = i.uv.x * cos(radians(_Angle)) / _Scale - i.uv.y * sin(radians(_Angle)) / _Scale;
                hue = frac(hue + frac(_Time.y * _Speed));
                float x = 1. - abs(fmod(hue / (1. / 6.), 2.) - 1.);
                fixed4 rainbow;
                if(hue < 1. / 6.){
                    rainbow = fixed4(1., x, 0., 1 * col.a);
                } else if (hue < 1. / 3.) {
                    rainbow = fixed4(x, 1., 0, 1 * col.a);
                } else if (hue < 0.5) {
                    rainbow = fixed4(0, 1., x, 1 * col.a);
                } else if (hue < 2. / 3.) {
                    rainbow = fixed4(0., x, 1., 1 * col.a);
                } else if (hue < 5. / 6.) {
                    rainbow = fixed4(x, 0., 1., 1 * col.a);
                } else {
                    rainbow = fixed4(1., 0., x, 1 * col.a);
                }
                return rainbow;
            }
            ENDCG
        }
    }
}
