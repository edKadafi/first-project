Shader "Graph/Point Surface"
{
    Properties
    {
        _Smoothness ("Smoothness", Range (0,1)) = 0.5
    }

    SubShader
    {

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        float _Smoothness;

        struct Input
        {
            float3 worldPos;
        };

        void surf (Input input, inout SurfaceOutputStandard o)
        {
            o.Smoothness = _Smoothness;
            o.Albedo = input.worldPos*0.5 + 0.5;
            
        }
        ENDCG
    }
    FallBack "Diffuse"
}
