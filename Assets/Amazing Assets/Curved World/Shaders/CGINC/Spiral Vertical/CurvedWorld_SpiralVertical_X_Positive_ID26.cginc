// Curved World <http://u3d.as/1W8h>
// Copyright (c) Amazing Assets <https://amazingassets.world>
 
#ifndef CURVEDWORLD_SPIRALVERTICAL_X_POSITIVE_ID26_CGINC
#define CURVEDWORLD_SPIRALVERTICAL_X_POSITIVE_ID26_CGINC

uniform float3 CurvedWorld_SpiralVertical_X_Positive_ID26_PivotPoint;
uniform float3 CurvedWorld_SpiralVertical_X_Positive_ID26_RotationCenter;
uniform float CurvedWorld_SpiralVertical_X_Positive_ID26_BendAngle;
uniform float CurvedWorld_SpiralVertical_X_Positive_ID26_BendMinimumRadius;

                 
#include "../../Core/Core.cginc"                           
             
      
////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                Main Method                                 //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_SpiralVertical_X_Positive_ID26(inout float4 vertexOS)
{
    CurvedWorld_SpiralVertical_X_Positive(vertexOS, 
							CurvedWorld_SpiralVertical_X_Positive_ID26_PivotPoint,
	                        CurvedWorld_SpiralVertical_X_Positive_ID26_RotationCenter,                            
							CurvedWorld_SpiralVertical_X_Positive_ID26_BendAngle,
							CurvedWorld_SpiralVertical_X_Positive_ID26_BendMinimumRadius);
}

void CurvedWorld_SpiralVertical_X_Positive_ID26(inout float4 vertexOS, inout float3 normalOS, float4 tangent)
{
    CurvedWorld_SpiralVertical_X_Positive(vertexOS, 
                            normalOS, 
                            tangent,
							CurvedWorld_SpiralVertical_X_Positive_ID26_PivotPoint,
                            CurvedWorld_SpiralVertical_X_Positive_ID26_RotationCenter,                            
							CurvedWorld_SpiralVertical_X_Positive_ID26_BendAngle,
							CurvedWorld_SpiralVertical_X_Positive_ID26_BendMinimumRadius);
}

void CurvedWorld_SpiralVertical_X_Positive_ID26(inout float3 vertexOS)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_SpiralVertical_X_Positive_ID26(vertex);

    vertexOS.xyz = vertex.xyz;
}

void CurvedWorld_SpiralVertical_X_Positive_ID26(inout float3 vertexOS, inout float3 normalOS, float4 tangent)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_SpiralVertical_X_Positive_ID26(vertex, normalOS, tangent);

    vertexOS.xyz = vertex.xyz;
} 

////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                               SubGraph Methods                             //
//                                                                            // 
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_SpiralVertical_X_Positive_ID26_float(float3 vertexOS, out float3 retVertex)
{
    CurvedWorld_SpiralVertical_X_Positive_ID26(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_SpiralVertical_X_Positive_ID26_half(half3 vertexOS, out half3 retVertex)
{
    CurvedWorld_SpiralVertical_X_Positive_ID26(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_SpiralVertical_X_Positive_ID26_float(float3 vertexOS, float3 normalOS, float4 tangent, out float3 retVertex, out float3 retNormal)
{
	CurvedWorld_SpiralVertical_X_Positive_ID26(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;
}

void CurvedWorld_SpiralVertical_X_Positive_ID26_half(half3 vertexOS, half3 normalOS, half4 tangent, out half3 retVertex, out float3 retNormal)
{
	CurvedWorld_SpiralVertical_X_Positive_ID26(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;	
}     

#endif
