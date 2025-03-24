// Curved World <http://u3d.as/1W8h>
// Copyright (c) Amazing Assets <https://amazingassets.world>
 
#ifndef CURVEDWORLD_CYLINDRICALTOWER_X_ID11_CGINC
#define CURVEDWORLD_CYLINDRICALTOWER_X_ID11_CGINC

uniform float3 CurvedWorld_CylindricalTower_X_ID11_PivotPoint;
uniform float CurvedWorld_CylindricalTower_X_ID11_BendSize;    
uniform float CurvedWorld_CylindricalTower_X_ID11_BendOffset;
  
                 
#include "../../Core/Core.cginc"                           
             
      
////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                Main Method                                 //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_CylindricalTower_X_ID11(inout float4 vertexOS)
{
    CurvedWorld_CylindricalTower_X(vertexOS, 
	                        CurvedWorld_CylindricalTower_X_ID11_PivotPoint,
							CurvedWorld_CylindricalTower_X_ID11_BendSize,
							CurvedWorld_CylindricalTower_X_ID11_BendOffset);
}

void CurvedWorld_CylindricalTower_X_ID11(inout float4 vertexOS, inout float3 normalOS, float4 tangent)
{
    CurvedWorld_CylindricalTower_X(vertexOS, 
                            normalOS, 
                            tangent,
                            CurvedWorld_CylindricalTower_X_ID11_PivotPoint,
                            CurvedWorld_CylindricalTower_X_ID11_BendSize,
                            CurvedWorld_CylindricalTower_X_ID11_BendOffset);
}    

void CurvedWorld_CylindricalTower_X_ID11(inout float3 vertexOS)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_CylindricalTower_X_ID11(vertex);

    vertexOS.xyz = vertex.xyz;
}

void CurvedWorld_CylindricalTower_X_ID11(inout float3 vertexOS, inout float3 normalOS, float4 tangent)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_CylindricalTower_X_ID11(vertex, normalOS, tangent);

    vertexOS.xyz = vertex.xyz;
}  
                  
////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                               SubGraph Methods                             //
//                                                                            // 
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_CylindricalTower_X_ID11_float(float3 vertexOS, out float3 retVertex)
{
    CurvedWorld_CylindricalTower_X_ID11(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_CylindricalTower_X_ID11_half(half3 vertexOS, out half3 retVertex)
{
    CurvedWorld_CylindricalTower_X_ID11(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_CylindricalTower_X_ID11_float(float3 vertexOS, float3 normalOS, float4 tangent, out float3 retVertex, out float3 retNormal)
{
	CurvedWorld_CylindricalTower_X_ID11(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;
}

void CurvedWorld_CylindricalTower_X_ID11_half(half3 vertexOS, half3 normalOS, half4 tangent, out half3 retVertex, out float3 retNormal)
{
	CurvedWorld_CylindricalTower_X_ID11(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;	
}     

#endif
