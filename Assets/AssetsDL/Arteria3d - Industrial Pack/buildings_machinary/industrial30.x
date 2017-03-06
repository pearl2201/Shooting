xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.18
// Time: Fri Sep 11 21:40:03 2009

// Start of Templates

template VertexDuplicationIndices {
 <b8d65549-d7c9-4995-89cf-53a9a8b031e3>
 DWORD nIndices;
 DWORD nOriginalVertices;
 array DWORD indices[nIndices];
}

template FVFData {
 <b6e70a0e-8ef9-4e83-94ad-ecc8b0c04897>
 DWORD dwFVF;
 DWORD nDWords;
 array DWORD data[nDWords];
}

template Header {
 <3D82AB43-62DA-11cf-AB39-0020AF71E433>
 WORD major;
 WORD minor;
 DWORD flags;
}

template Vector {
 <3D82AB5E-62DA-11cf-AB39-0020AF71E433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template Coords2d {
 <F6F23F44-7686-11cf-8F52-0040333594A3>
 FLOAT u;
 FLOAT v;
}

template Matrix4x4 {
 <F6F23F45-7686-11cf-8F52-0040333594A3>
 array FLOAT matrix[16];
}

template ColorRGBA {
 <35FF44E0-6C7C-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <D3E16E81-7835-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template IndexedColor {
 <1630B820-7842-11cf-8F52-0040333594A3>
 DWORD index;
 ColorRGBA indexColor;
}

template Material {
 <3D82AB4D-62DA-11cf-AB39-0020AF71E433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template TextureFilename {
 <A42790E1-7810-11cf-8F52-0040333594A3>
 STRING filename;
}

template MeshFace {
 <3D82AB5F-62DA-11cf-AB39-0020AF71E433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template MeshTextureCoords {
 <F6F23F40-7686-11cf-8F52-0040333594A3>
 DWORD nTextureCoords;
 array Coords2d textureCoords[nTextureCoords];
}

template MeshMaterialList {
 <F6F23F42-7686-11cf-8F52-0040333594A3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material]
}

template MeshNormals {
 <F6F23F43-7686-11cf-8F52-0040333594A3>
 DWORD nNormals;
 array Vector normals[nNormals];
 DWORD nFaceNormals;
 array MeshFace faceNormals[nFaceNormals];
}

template MeshVertexColors {
 <1630B821-7842-11cf-8F52-0040333594A3>
 DWORD nVertexColors;
 array IndexedColor vertexColors[nVertexColors];
}

template Mesh {
 <3D82AB44-62DA-11cf-AB39-0020AF71E433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

template FrameTransformMatrix {
 <F6F23F41-7686-11cf-8F52-0040333594A3>
 Matrix4x4 frameMatrix;
}

template Frame {
 <3D82AB46-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template FloatKeys {
 <10DD46A9-775B-11cf-8F52-0040333594A3>
 DWORD nValues;
 array FLOAT values[nValues];
}

template TimedFloatKeys {
 <F406B180-7B3B-11cf-8F52-0040333594A3>
 DWORD time;
 FloatKeys tfkeys;
}

template AnimationKey {
 <10DD46A8-775B-11cf-8F52-0040333594A3>
 DWORD keyType;
 DWORD nKeys;
 array TimedFloatKeys keys[nKeys];
}

template AnimationOptions {
 <E2BF56C0-840F-11cf-8F52-0040333594A3>
 DWORD openclosed;
 DWORD positionquality;
}

template Animation {
 <3D82AB4F-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template AnimationSet {
 <3D82AB50-62DA-11cf-AB39-0020AF71E433>
 [Animation]
}

template XSkinMeshHeader {
 <3CF169CE-FF7C-44ab-93C0-F78F62D172E2>
 WORD nMaxSkinWeightsPerVertex;
 WORD nMaxSkinWeightsPerFace;
 WORD nBones;
}

template SkinWeights {
 <6F0D123B-BAD2-4167-A0D0-80224F25FABB>
 STRING transformNodeName;
 DWORD nWeights;
 array DWORD vertexIndices[nWeights];
 array FLOAT weights[nWeights];
 Matrix4x4 matrixOffset;
}

template AnimTicksPerSecond {
 <9E415A43-7BA6-4a73-8743-B73D47E88476>
 DWORD AnimTicksPerSecond;
}

AnimTicksPerSecond {
 4800;
}

// Start of Frames

Frame Body {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh staticMesh {
    144;
    31.899998; 0.000000; -21.742249;,
    31.899998; 3.644882; -21.742249;,
    31.899998; 0.000000; 16.223949;,
    31.899998; 3.644882; 16.223949;,
    -31.899998; 0.000000; 16.223949;,
    -31.899998; 3.644882; 16.223949;,
    -31.899998; 0.000000; -21.742249;,
    -31.899998; 3.644882; -21.742249;,
    31.899998; 0.000000; 21.742249;,
    31.899998; 3.644882; 21.742249;,
    -31.899998; 3.644882; 21.742249;,
    -31.899998; 0.000000; 21.742249;,
    31.899998; 69.593658; -21.742249;,
    31.899998; 100.345062; -21.742249;,
    31.899998; 69.593658; 16.223949;,
    31.899998; 100.345062; 16.223949;,
    -31.899998; 69.593658; -21.742249;,
    -31.899998; 69.593658; 16.223949;,
    -31.899998; 100.345062; -21.742249;,
    -31.899998; 100.345062; 16.223949;,
    -11.307301; 102.096764; -21.742249;,
    -31.899998; 102.096764; -21.742249;,
    -11.307301; 102.096764; 16.223949;,
    -31.899998; 102.096764; 16.223949;,
    -11.307301; 0.000000; -21.742249;,
    -11.307301; 0.000000; 16.223949;,
    -31.899998; 0.000000; -21.742249;,
    -31.899998; 0.000000; 16.223949;,
    -31.899998; 0.000000; -21.742249;,
    -31.899998; 3.644882; -21.742249;,
    -11.307301; 0.000000; -21.742249;,
    -11.307301; 3.644882; -21.742249;,
    -11.307301; 0.000000; 21.742249;,
    -11.307301; 3.644882; 21.742249;,
    -31.899998; 0.000000; 21.742249;,
    -31.899998; 3.644882; 21.742249;,
    -11.307301; 3.644882; 21.742249;,
    -11.307301; 3.644882; 16.223949;,
    -31.899998; 3.644882; 21.742249;,
    -31.899998; 3.644882; 16.223949;,
    -31.899998; 0.000000; 21.742249;,
    -11.307301; 0.000000; 21.742249;,
    -11.307301; 69.593658; -21.742249;,
    -31.899998; 69.593658; -21.742249;,
    -11.307301; 69.593658; -21.742249;,
    -31.899998; 69.593658; -21.742249;,
    -11.307301; 100.345062; -21.742249;,
    -31.899998; 100.345062; -21.742249;,
    -11.307301; 3.644882; 16.223949;,
    -11.307301; 69.593658; 16.223949;,
    -31.899998; 3.644882; 16.223949;,
    -31.899998; 69.593658; 16.223949;,
    -11.307301; 69.593658; 18.106548;,
    -11.307301; 100.345062; 18.106548;,
    -31.899998; 69.593658; 18.106548;,
    -31.899998; 100.345062; 18.106548;,
    13.178100; 102.096764; -21.742249;,
    13.178100; 102.096764; 16.223949;,
    31.899998; 102.096764; -21.742249;,
    31.899998; 102.096764; 16.223949;,
    13.178100; 0.000000; -21.742249;,
    31.899998; 0.000000; -21.742249;,
    13.178100; 0.000000; 16.223949;,
    31.899998; 0.000000; 16.223949;,
    13.178100; 0.000000; -21.742249;,
    13.178100; 3.644882; -21.742249;,
    31.899998; 0.000000; -21.742249;,
    31.899998; 3.644882; -21.742249;,
    31.899998; 0.000000; 21.742249;,
    31.899998; 3.644882; 21.742249;,
    13.178100; 0.000000; 21.742249;,
    13.178100; 3.644882; 21.742249;,
    31.899998; 3.644882; 21.742249;,
    31.899998; 3.644882; 16.223949;,
    13.178100; 3.644882; 21.742249;,
    13.178100; 3.644882; 16.223949;,
    13.178100; 0.000000; 21.742249;,
    31.899998; 0.000000; 21.742249;,
    13.178100; 69.593658; -21.742249;,
    31.899998; 69.593658; -21.742249;,
    13.178100; 69.593658; -21.742249;,
    13.178100; 100.345062; -21.742249;,
    31.899998; 69.593658; -21.742249;,
    31.899998; 100.345062; -21.742249;,
    13.178100; 3.644882; 16.223949;,
    31.899998; 3.644882; 16.223949;,
    13.178100; 69.593658; 16.223949;,
    31.899998; 69.593658; 16.223949;,
    13.178100; 3.644882; 18.106548;,
    13.178100; 69.593658; 18.106548;,
    -11.307301; 3.644882; 18.106548;,
    31.899998; 69.593658; 18.106548;,
    13.178100; 100.345062; 18.106548;,
    31.899998; 100.345062; 18.106548;,
    -31.899998; 100.345062; 18.106548;,
    -31.899998; 69.593658; 18.106548;,
    -11.307301; 102.096764; 18.106548;,
    -31.899998; 102.096764; 18.106548;,
    31.899998; 69.593658; 18.106548;,
    31.899998; 100.345062; 18.106548;,
    31.899998; 102.096764; 18.106548;,
    13.178100; 102.096764; 18.106548;,
    -31.899998; 69.593658; 18.106548;,
    -31.899998; 69.593658; 16.223949;,
    -11.307301; 69.593658; 18.106548;,
    -11.307301; 69.593658; 16.223949;,
    13.178100; 69.593658; 18.106548;,
    13.178100; 69.593658; 16.223949;,
    31.899998; 69.593658; 18.106548;,
    31.899998; 69.593658; 16.223949;,
    -11.307301; 69.593658; 18.106548;,
    -11.307301; 69.593658; 16.223949;,
    -11.307301; 3.644882; 18.106548;,
    -11.307301; 3.644882; 16.223949;,
    13.178100; 3.644882; 18.106548;,
    13.178100; 3.644882; 16.223949;,
    13.178100; 69.593658; 18.106548;,
    13.178100; 69.593658; 16.223949;,
    -31.899998; 102.096764; -21.742249;,
    -31.899998; 102.096764; 16.223949;,
    -11.307301; 102.096764; -21.742249;,
    -31.899998; 102.096764; -21.742249;,
    31.899998; 102.096764; 16.223949;,
    31.899998; 102.096764; -21.742249;,
    31.899998; 102.096764; -21.742249;,
    13.178100; 102.096764; -21.742249;,
    -31.899998; 102.096764; 18.106548;,
    31.899998; 102.096764; 18.106548;,
    -31.899998; 102.096764; 21.136650;,
    -31.899998; 100.345062; 21.136650;,
    -11.307301; 102.096764; 21.136650;,
    -11.307301; 100.345062; 21.136650;,
    13.178100; 102.096764; 21.136650;,
    13.178100; 100.345062; 21.136650;,
    31.899998; 102.096764; 21.136650;,
    31.899998; 100.345062; 21.136650;,
    -31.899998; 102.096764; 21.136650;,
    -31.899998; 100.345062; 21.136650;,
    31.899998; 100.345062; 21.136650;,
    31.899998; 102.096764; 21.136650;,
    -11.307301; 102.096764; 21.136650;,
    -31.899998; 102.096764; 21.136650;,
    31.899998; 102.096764; 21.136650;,
    13.178100; 102.096764; 21.136650;;
    132;
    3;0, 1, 2;,
    3;1, 3, 2;,
    3;4, 5, 6;,
    3;5, 7, 6;,
    3;8, 2, 9;,
    3;2, 3, 9;,
    3;10, 5, 11;,
    3;5, 4, 11;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;12, 14, 1;,
    3;14, 3, 1;,
    3;16, 7, 17;,
    3;7, 5, 17;,
    3;16, 17, 18;,
    3;17, 19, 18;,
    3;20, 21, 22;,
    3;21, 23, 22;,
    3;24, 25, 26;,
    3;25, 27, 26;,
    3;28, 29, 30;,
    3;29, 31, 30;,
    3;32, 33, 34;,
    3;33, 35, 34;,
    3;36, 37, 38;,
    3;37, 39, 38;,
    3;40, 27, 41;,
    3;27, 25, 41;,
    3;31, 29, 42;,
    3;29, 43, 42;,
    3;44, 45, 46;,
    3;45, 47, 46;,
    3;48, 49, 50;,
    3;49, 51, 50;,
    3;52, 53, 54;,
    3;53, 55, 54;,
    3;20, 22, 56;,
    3;22, 57, 56;,
    3;56, 57, 58;,
    3;57, 59, 58;,
    3;60, 61, 62;,
    3;61, 63, 62;,
    3;60, 62, 24;,
    3;62, 25, 24;,
    3;30, 31, 64;,
    3;31, 65, 64;,
    3;64, 65, 66;,
    3;65, 67, 66;,
    3;68, 69, 70;,
    3;69, 71, 70;,
    3;70, 71, 32;,
    3;71, 33, 32;,
    3;72, 73, 74;,
    3;73, 75, 74;,
    3;74, 75, 36;,
    3;75, 37, 36;,
    3;41, 25, 76;,
    3;25, 62, 76;,
    3;76, 62, 77;,
    3;62, 63, 77;,
    3;31, 42, 65;,
    3;42, 78, 65;,
    3;65, 78, 67;,
    3;78, 79, 67;,
    3;44, 46, 80;,
    3;46, 81, 80;,
    3;80, 81, 82;,
    3;81, 83, 82;,
    3;84, 85, 86;,
    3;85, 87, 86;,
    3;88, 89, 90;,
    3;89, 52, 90;,
    3;89, 91, 92;,
    3;91, 93, 92;,
    3;89, 92, 52;,
    3;92, 53, 52;,
    3;94, 19, 95;,
    3;19, 17, 95;,
    3;96, 22, 97;,
    3;22, 23, 97;,
    3;98, 14, 99;,
    3;14, 15, 99;,
    3;100, 59, 101;,
    3;59, 57, 101;,
    3;102, 103, 104;,
    3;103, 105, 104;,
    3;106, 107, 108;,
    3;107, 109, 108;,
    3;110, 111, 112;,
    3;111, 113, 112;,
    3;90, 48, 88;,
    3;48, 84, 88;,
    3;101, 57, 96;,
    3;57, 22, 96;,
    3;114, 115, 116;,
    3;115, 117, 116;,
    3;118, 18, 119;,
    3;18, 19, 119;,
    3;120, 46, 121;,
    3;46, 47, 121;,
    3;122, 15, 123;,
    3;15, 13, 123;,
    3;124, 83, 125;,
    3;83, 81, 125;,
    3;119, 19, 126;,
    3;19, 94, 126;,
    3;127, 99, 122;,
    3;99, 15, 122;,
    3;125, 81, 120;,
    3;81, 46, 120;,
    3;128, 129, 130;,
    3;129, 131, 130;,
    3;130, 131, 132;,
    3;131, 133, 132;,
    3;132, 133, 134;,
    3;133, 135, 134;,
    3;129, 55, 131;,
    3;55, 53, 131;,
    3;136, 126, 137;,
    3;126, 94, 137;,
    3;131, 53, 133;,
    3;53, 92, 133;,
    3;133, 92, 135;,
    3;92, 93, 135;,
    3;138, 99, 139;,
    3;99, 127, 139;,
    3;140, 96, 141;,
    3;96, 97, 141;,
    3;142, 100, 143;,
    3;100, 101, 143;,
    3;143, 101, 140;,
    3;101, 96, 140;;

   MeshNormals {
    144;
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; -0.894427; 0.447214;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.707107; 0.707107;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.894427; 0.447214;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; -0.707107; 0.707107;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.894427; 0.447214;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.447214; 0.894427;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.600000; 0.800000;,
    0.000000; -0.707107; 0.707107;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    -1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.447214; 0.894427;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.707107; 0.707107;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.707107; 0.707107;,
    0.000000; 0.000000; 1.000000;,
    0.000000; -0.894427; 0.447214;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;,
    0.000000; 1.000000; 0.000000;;
    132;
    3;0, 1, 2;,
    3;1, 3, 2;,
    3;4, 5, 6;,
    3;5, 7, 6;,
    3;8, 2, 9;,
    3;2, 3, 9;,
    3;10, 5, 11;,
    3;5, 4, 11;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;12, 14, 1;,
    3;14, 3, 1;,
    3;16, 7, 17;,
    3;7, 5, 17;,
    3;16, 17, 18;,
    3;17, 19, 18;,
    3;20, 21, 22;,
    3;21, 23, 22;,
    3;24, 25, 26;,
    3;25, 27, 26;,
    3;28, 29, 30;,
    3;29, 31, 30;,
    3;32, 33, 34;,
    3;33, 35, 34;,
    3;36, 37, 38;,
    3;37, 39, 38;,
    3;40, 27, 41;,
    3;27, 25, 41;,
    3;31, 29, 42;,
    3;29, 43, 42;,
    3;44, 45, 46;,
    3;45, 47, 46;,
    3;48, 49, 50;,
    3;49, 51, 50;,
    3;52, 53, 54;,
    3;53, 55, 54;,
    3;20, 22, 56;,
    3;22, 57, 56;,
    3;56, 57, 58;,
    3;57, 59, 58;,
    3;60, 61, 62;,
    3;61, 63, 62;,
    3;60, 62, 24;,
    3;62, 25, 24;,
    3;30, 31, 64;,
    3;31, 65, 64;,
    3;64, 65, 66;,
    3;65, 67, 66;,
    3;68, 69, 70;,
    3;69, 71, 70;,
    3;70, 71, 32;,
    3;71, 33, 32;,
    3;72, 73, 74;,
    3;73, 75, 74;,
    3;74, 75, 36;,
    3;75, 37, 36;,
    3;41, 25, 76;,
    3;25, 62, 76;,
    3;76, 62, 77;,
    3;62, 63, 77;,
    3;31, 42, 65;,
    3;42, 78, 65;,
    3;65, 78, 67;,
    3;78, 79, 67;,
    3;44, 46, 80;,
    3;46, 81, 80;,
    3;80, 81, 82;,
    3;81, 83, 82;,
    3;84, 85, 86;,
    3;85, 87, 86;,
    3;88, 89, 90;,
    3;89, 52, 90;,
    3;89, 91, 92;,
    3;91, 93, 92;,
    3;89, 92, 52;,
    3;92, 53, 52;,
    3;94, 19, 95;,
    3;19, 17, 95;,
    3;96, 22, 97;,
    3;22, 23, 97;,
    3;98, 14, 99;,
    3;14, 15, 99;,
    3;100, 59, 101;,
    3;59, 57, 101;,
    3;102, 103, 104;,
    3;103, 105, 104;,
    3;106, 107, 108;,
    3;107, 109, 108;,
    3;110, 111, 112;,
    3;111, 113, 112;,
    3;90, 48, 88;,
    3;48, 84, 88;,
    3;101, 57, 96;,
    3;57, 22, 96;,
    3;114, 115, 116;,
    3;115, 117, 116;,
    3;118, 18, 119;,
    3;18, 19, 119;,
    3;120, 46, 121;,
    3;46, 47, 121;,
    3;122, 15, 123;,
    3;15, 13, 123;,
    3;124, 83, 125;,
    3;83, 81, 125;,
    3;119, 19, 126;,
    3;19, 94, 126;,
    3;127, 99, 122;,
    3;99, 15, 122;,
    3;125, 81, 120;,
    3;81, 46, 120;,
    3;128, 129, 130;,
    3;129, 131, 130;,
    3;130, 131, 132;,
    3;131, 133, 132;,
    3;132, 133, 134;,
    3;133, 135, 134;,
    3;129, 55, 131;,
    3;55, 53, 131;,
    3;136, 126, 137;,
    3;126, 94, 137;,
    3;131, 53, 133;,
    3;53, 92, 133;,
    3;133, 92, 135;,
    3;92, 93, 135;,
    3;138, 99, 139;,
    3;99, 127, 139;,
    3;140, 96, 141;,
    3;96, 97, 141;,
    3;142, 100, 143;,
    3;100, 101, 143;,
    3;143, 101, 140;,
    3;101, 96, 140;;
   }

   MeshTextureCoords {
    144;
    0.775916; 0.961865;,
    0.775916; 0.934019;,
    0.586266; 0.961865;,
    0.586266; 0.934019;,
    0.586266; 0.961865;,
    0.586266; 0.934019;,
    0.775916; 0.961865;,
    0.775916; 0.934019;,
    0.558700; 0.961865;,
    0.558700; 0.934019;,
    0.558700; 0.934019;,
    0.558700; 0.961865;,
    0.775916; 0.430183;,
    0.775916; 0.195248;,
    0.586266; 0.430183;,
    0.586266; 0.195248;,
    0.775916; 0.430183;,
    0.586266; 0.430183;,
    0.775916; 0.195248;,
    0.586266; 0.195248;,
    0.351051; 0.530346;,
    0.351051; 0.405724;,
    0.193949; 0.530346;,
    0.193949; 0.405724;,
    0.767366; 0.533263;,
    0.615441; 0.533263;,
    0.767366; 0.407867;,
    0.615441; 0.407867;,
    0.165953; 0.993207;,
    0.165953; 0.957864;,
    0.363953; 0.993207;,
    0.363953; 0.957864;,
    0.363953; 0.993207;,
    0.363953; 0.957864;,
    0.165953; 0.993207;,
    0.165953; 0.957864;,
    0.593359; 0.533263;,
    0.615441; 0.533263;,
    0.593359; 0.407867;,
    0.615441; 0.407867;,
    0.593359; 0.407867;,
    0.593359; 0.533263;,
    0.363953; 0.335522;,
    0.165953; 0.335522;,
    0.594418; 0.589271;,
    0.594418; 0.428891;,
    0.755235; 0.589271;,
    0.755235; 0.428891;,
    0.363953; 0.957864;,
    0.363953; 0.335522;,
    0.165953; 0.957864;,
    0.165953; 0.335522;,
    0.363953; 0.335522;,
    0.363953; 0.020193;,
    0.165953; 0.335522;,
    0.165953; 0.020193;,
    0.351051; 0.678526;,
    0.193949; 0.678526;,
    0.351051; 0.791826;,
    0.193949; 0.791826;,
    0.767366; 0.682363;,
    0.767366; 0.796367;,
    0.615441; 0.682363;,
    0.615441; 0.796367;,
    0.601891; 0.993207;,
    0.601891; 0.957864;,
    0.797099; 0.993207;,
    0.797099; 0.957864;,
    0.797099; 0.993207;,
    0.797099; 0.957864;,
    0.601891; 0.993207;,
    0.601891; 0.957864;,
    0.593359; 0.796367;,
    0.615441; 0.796367;,
    0.593359; 0.682363;,
    0.615441; 0.682363;,
    0.593359; 0.682363;,
    0.593359; 0.796367;,
    0.601891; 0.335522;,
    0.797099; 0.335522;,
    0.594418; 0.782001;,
    0.755235; 0.782001;,
    0.594418; 0.940119;,
    0.755235; 0.940119;,
    0.601891; 0.957864;,
    0.797099; 0.957864;,
    0.601891; 0.335522;,
    0.797099; 0.335522;,
    0.601891; 0.957864;,
    0.601891; 0.335522;,
    0.363953; 0.957864;,
    0.797099; 0.335522;,
    0.601891; 0.020193;,
    0.797099; 0.020193;,
    0.576862; 0.195248;,
    0.576862; 0.430183;,
    0.186159; 0.530346;,
    0.186159; 0.405724;,
    0.576862; 0.430183;,
    0.576862; 0.195248;,
    0.186159; 0.791826;,
    0.186159; 0.678526;,
    0.196526; 0.909830;,
    0.196526; 0.893011;,
    0.380504; 0.909830;,
    0.380504; 0.893011;,
    0.599261; 0.909830;,
    0.599261; 0.893011;,
    0.766526; 0.909830;,
    0.766526; 0.893011;,
    0.222941; 0.358122;,
    0.251487; 0.358122;,
    0.222941; 0.918122;,
    0.251487; 0.918122;,
    0.222941; 0.918122;,
    0.251487; 0.918122;,
    0.222941; 0.358122;,
    0.251487; 0.358122;,
    0.775916; 0.181866;,
    0.586266; 0.181866;,
    0.763898; 0.589271;,
    0.763898; 0.428891;,
    0.586266; 0.181866;,
    0.775916; 0.181866;,
    0.763898; 0.940119;,
    0.763898; 0.782001;,
    0.576862; 0.181866;,
    0.576862; 0.181866;,
    0.165953; 0.003208;,
    0.165953; 0.020193;,
    0.363953; 0.003208;,
    0.363953; 0.020193;,
    0.601891; 0.003208;,
    0.601891; 0.020193;,
    0.797099; 0.003208;,
    0.797099; 0.020193;,
    0.561725; 0.181866;,
    0.561725; 0.195248;,
    0.561725; 0.195248;,
    0.561725; 0.181866;,
    0.173620; 0.530346;,
    0.173620; 0.405724;,
    0.173620; 0.791826;,
    0.173620; 0.678526;;
   }

   MeshVertexColors {
    144;
    0; 1.000000; 1.000000; 1.000000; 1.000000;,
    1; 1.000000; 1.000000; 1.000000; 1.000000;,
    2; 1.000000; 1.000000; 1.000000; 1.000000;,
    3; 1.000000; 1.000000; 1.000000; 1.000000;,
    4; 1.000000; 1.000000; 1.000000; 1.000000;,
    5; 1.000000; 1.000000; 1.000000; 1.000000;,
    6; 1.000000; 1.000000; 1.000000; 1.000000;,
    7; 1.000000; 1.000000; 1.000000; 1.000000;,
    8; 1.000000; 1.000000; 1.000000; 1.000000;,
    9; 1.000000; 1.000000; 1.000000; 1.000000;,
    10; 1.000000; 1.000000; 1.000000; 1.000000;,
    11; 1.000000; 1.000000; 1.000000; 1.000000;,
    12; 1.000000; 1.000000; 1.000000; 1.000000;,
    13; 1.000000; 1.000000; 1.000000; 1.000000;,
    14; 1.000000; 1.000000; 1.000000; 1.000000;,
    15; 1.000000; 1.000000; 1.000000; 1.000000;,
    16; 1.000000; 1.000000; 1.000000; 1.000000;,
    17; 1.000000; 1.000000; 1.000000; 1.000000;,
    18; 1.000000; 1.000000; 1.000000; 1.000000;,
    19; 1.000000; 1.000000; 1.000000; 1.000000;,
    20; 1.000000; 1.000000; 1.000000; 1.000000;,
    21; 1.000000; 1.000000; 1.000000; 1.000000;,
    22; 1.000000; 1.000000; 1.000000; 1.000000;,
    23; 1.000000; 1.000000; 1.000000; 1.000000;,
    24; 1.000000; 1.000000; 1.000000; 1.000000;,
    25; 1.000000; 1.000000; 1.000000; 1.000000;,
    26; 1.000000; 1.000000; 1.000000; 1.000000;,
    27; 1.000000; 1.000000; 1.000000; 1.000000;,
    28; 1.000000; 1.000000; 1.000000; 1.000000;,
    29; 1.000000; 1.000000; 1.000000; 1.000000;,
    30; 1.000000; 1.000000; 1.000000; 1.000000;,
    31; 1.000000; 1.000000; 1.000000; 1.000000;,
    32; 1.000000; 1.000000; 1.000000; 1.000000;,
    33; 1.000000; 1.000000; 1.000000; 1.000000;,
    34; 1.000000; 1.000000; 1.000000; 1.000000;,
    35; 1.000000; 1.000000; 1.000000; 1.000000;,
    36; 1.000000; 1.000000; 1.000000; 1.000000;,
    37; 1.000000; 1.000000; 1.000000; 1.000000;,
    38; 1.000000; 1.000000; 1.000000; 1.000000;,
    39; 1.000000; 1.000000; 1.000000; 1.000000;,
    40; 1.000000; 1.000000; 1.000000; 1.000000;,
    41; 1.000000; 1.000000; 1.000000; 1.000000;,
    42; 1.000000; 1.000000; 1.000000; 1.000000;,
    43; 1.000000; 1.000000; 1.000000; 1.000000;,
    44; 1.000000; 1.000000; 1.000000; 1.000000;,
    45; 1.000000; 1.000000; 1.000000; 1.000000;,
    46; 1.000000; 1.000000; 1.000000; 1.000000;,
    47; 1.000000; 1.000000; 1.000000; 1.000000;,
    48; 1.000000; 1.000000; 1.000000; 1.000000;,
    49; 1.000000; 1.000000; 1.000000; 1.000000;,
    50; 1.000000; 1.000000; 1.000000; 1.000000;,
    51; 1.000000; 1.000000; 1.000000; 1.000000;,
    52; 1.000000; 1.000000; 1.000000; 1.000000;,
    53; 1.000000; 1.000000; 1.000000; 1.000000;,
    54; 1.000000; 1.000000; 1.000000; 1.000000;,
    55; 1.000000; 1.000000; 1.000000; 1.000000;,
    56; 1.000000; 1.000000; 1.000000; 1.000000;,
    57; 1.000000; 1.000000; 1.000000; 1.000000;,
    58; 1.000000; 1.000000; 1.000000; 1.000000;,
    59; 1.000000; 1.000000; 1.000000; 1.000000;,
    60; 1.000000; 1.000000; 1.000000; 1.000000;,
    61; 1.000000; 1.000000; 1.000000; 1.000000;,
    62; 1.000000; 1.000000; 1.000000; 1.000000;,
    63; 1.000000; 1.000000; 1.000000; 1.000000;,
    64; 1.000000; 1.000000; 1.000000; 1.000000;,
    65; 1.000000; 1.000000; 1.000000; 1.000000;,
    66; 1.000000; 1.000000; 1.000000; 1.000000;,
    67; 1.000000; 1.000000; 1.000000; 1.000000;,
    68; 1.000000; 1.000000; 1.000000; 1.000000;,
    69; 1.000000; 1.000000; 1.000000; 1.000000;,
    70; 1.000000; 1.000000; 1.000000; 1.000000;,
    71; 1.000000; 1.000000; 1.000000; 1.000000;,
    72; 1.000000; 1.000000; 1.000000; 1.000000;,
    73; 1.000000; 1.000000; 1.000000; 1.000000;,
    74; 1.000000; 1.000000; 1.000000; 1.000000;,
    75; 1.000000; 1.000000; 1.000000; 1.000000;,
    76; 1.000000; 1.000000; 1.000000; 1.000000;,
    77; 1.000000; 1.000000; 1.000000; 1.000000;,
    78; 1.000000; 1.000000; 1.000000; 1.000000;,
    79; 1.000000; 1.000000; 1.000000; 1.000000;,
    80; 1.000000; 1.000000; 1.000000; 1.000000;,
    81; 1.000000; 1.000000; 1.000000; 1.000000;,
    82; 1.000000; 1.000000; 1.000000; 1.000000;,
    83; 1.000000; 1.000000; 1.000000; 1.000000;,
    84; 1.000000; 1.000000; 1.000000; 1.000000;,
    85; 1.000000; 1.000000; 1.000000; 1.000000;,
    86; 1.000000; 1.000000; 1.000000; 1.000000;,
    87; 1.000000; 1.000000; 1.000000; 1.000000;,
    88; 1.000000; 1.000000; 1.000000; 1.000000;,
    89; 1.000000; 1.000000; 1.000000; 1.000000;,
    90; 1.000000; 1.000000; 1.000000; 1.000000;,
    91; 1.000000; 1.000000; 1.000000; 1.000000;,
    92; 1.000000; 1.000000; 1.000000; 1.000000;,
    93; 1.000000; 1.000000; 1.000000; 1.000000;,
    94; 1.000000; 1.000000; 1.000000; 1.000000;,
    95; 1.000000; 1.000000; 1.000000; 1.000000;,
    96; 1.000000; 1.000000; 1.000000; 1.000000;,
    97; 1.000000; 1.000000; 1.000000; 1.000000;,
    98; 1.000000; 1.000000; 1.000000; 1.000000;,
    99; 1.000000; 1.000000; 1.000000; 1.000000;,
    100; 1.000000; 1.000000; 1.000000; 1.000000;,
    101; 1.000000; 1.000000; 1.000000; 1.000000;,
    102; 1.000000; 1.000000; 1.000000; 1.000000;,
    103; 1.000000; 1.000000; 1.000000; 1.000000;,
    104; 1.000000; 1.000000; 1.000000; 1.000000;,
    105; 1.000000; 1.000000; 1.000000; 1.000000;,
    106; 1.000000; 1.000000; 1.000000; 1.000000;,
    107; 1.000000; 1.000000; 1.000000; 1.000000;,
    108; 1.000000; 1.000000; 1.000000; 1.000000;,
    109; 1.000000; 1.000000; 1.000000; 1.000000;,
    110; 1.000000; 1.000000; 1.000000; 1.000000;,
    111; 1.000000; 1.000000; 1.000000; 1.000000;,
    112; 1.000000; 1.000000; 1.000000; 1.000000;,
    113; 1.000000; 1.000000; 1.000000; 1.000000;,
    114; 1.000000; 1.000000; 1.000000; 1.000000;,
    115; 1.000000; 1.000000; 1.000000; 1.000000;,
    116; 1.000000; 1.000000; 1.000000; 1.000000;,
    117; 1.000000; 1.000000; 1.000000; 1.000000;,
    118; 1.000000; 1.000000; 1.000000; 1.000000;,
    119; 1.000000; 1.000000; 1.000000; 1.000000;,
    120; 1.000000; 1.000000; 1.000000; 1.000000;,
    121; 1.000000; 1.000000; 1.000000; 1.000000;,
    122; 1.000000; 1.000000; 1.000000; 1.000000;,
    123; 1.000000; 1.000000; 1.000000; 1.000000;,
    124; 1.000000; 1.000000; 1.000000; 1.000000;,
    125; 1.000000; 1.000000; 1.000000; 1.000000;,
    126; 1.000000; 1.000000; 1.000000; 1.000000;,
    127; 1.000000; 1.000000; 1.000000; 1.000000;,
    128; 1.000000; 1.000000; 1.000000; 1.000000;,
    129; 1.000000; 1.000000; 1.000000; 1.000000;,
    130; 1.000000; 1.000000; 1.000000; 1.000000;,
    131; 1.000000; 1.000000; 1.000000; 1.000000;,
    132; 1.000000; 1.000000; 1.000000; 1.000000;,
    133; 1.000000; 1.000000; 1.000000; 1.000000;,
    134; 1.000000; 1.000000; 1.000000; 1.000000;,
    135; 1.000000; 1.000000; 1.000000; 1.000000;,
    136; 1.000000; 1.000000; 1.000000; 1.000000;,
    137; 1.000000; 1.000000; 1.000000; 1.000000;,
    138; 1.000000; 1.000000; 1.000000; 1.000000;,
    139; 1.000000; 1.000000; 1.000000; 1.000000;,
    140; 1.000000; 1.000000; 1.000000; 1.000000;,
    141; 1.000000; 1.000000; 1.000000; 1.000000;,
    142; 1.000000; 1.000000; 1.000000; 1.000000;,
    143; 1.000000; 1.000000; 1.000000; 1.000000;;
   }

   MeshMaterialList {
    1;
    132;
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0;

    Material industrial22 {
     0.992157; 0.992157; 0.992157; 1.000000;;
     128.000000;
     0.150000; 0.150000; 0.150000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "industrial22.dds";
     }
    }

   }
  }
}
