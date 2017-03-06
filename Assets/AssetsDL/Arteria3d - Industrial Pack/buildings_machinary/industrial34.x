xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.18
// Time: Fri Sep 11 21:41:14 2009

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
    76;
    74.777596; 65.007301; -37.973450;,
    -74.777603; 65.007301; -37.973450;,
    74.777596; 65.007301; 37.219078;,
    -74.777603; 65.007301; 37.219078;,
    61.710899; 0.000000; -37.973450;,
    61.710899; 0.000000; 37.219078;,
    -45.723602; 0.000000; -37.973450;,
    -45.723602; 0.000000; 37.219078;,
    79.905602; 60.534302; -40.551674;,
    79.905602; 65.155602; -40.551674;,
    79.905602; 60.534302; 39.797279;,
    79.905602; 65.155602; 39.797279;,
    74.777596; 60.682602; -37.973450;,
    74.777596; 60.682602; 37.219078;,
    74.777596; 11.399002; -37.973450;,
    74.777596; 11.399002; 37.219078;,
    -55.812401; 11.756500; -37.973450;,
    -55.812401; 11.756500; 37.219078;,
    -74.777603; 60.682602; -37.973450;,
    -74.777603; 60.682602; 37.219078;,
    -79.905602; 60.534302; -40.551674;,
    -79.905602; 60.534302; 39.797279;,
    -79.905602; 65.155602; -40.551674;,
    -79.905602; 65.155602; 39.797279;,
    79.905602; 60.534302; -40.551674;,
    -79.905602; 60.534302; -40.551674;,
    79.905602; 65.155602; -40.551674;,
    -79.905602; 65.155602; -40.551674;,
    -79.905602; 60.534302; 39.797279;,
    79.905602; 60.534302; 39.797279;,
    -79.905602; 65.155602; 39.797279;,
    79.905602; 65.155602; 39.797279;,
    -79.905602; 65.155602; -40.551674;,
    79.905602; 65.155602; -40.551674;,
    -79.905602; 65.155602; 39.797279;,
    79.905602; 65.155602; 39.797279;,
    -79.905602; 60.534302; -40.551674;,
    -74.777603; 60.682602; -37.973450;,
    -79.905602; 60.534302; 39.797279;,
    -74.777603; 60.682602; 37.219078;,
    79.905602; 60.534302; -40.551674;,
    74.777596; 60.682602; -37.973450;,
    79.905602; 60.534302; 39.797279;,
    74.777596; 60.682602; 37.219078;,
    61.710899; 0.000000; 40.983276;,
    74.777596; 11.399002; 40.983276;,
    -45.723602; 0.000000; 40.983276;,
    -55.812401; 11.756500; 40.983276;,
    -55.812401; 11.756500; 37.219078;,
    74.777596; 11.399002; 37.219078;,
    -74.777603; 60.682602; 37.219078;,
    74.777596; 60.682602; 37.219078;,
    -45.723602; 0.000000; -40.983276;,
    -55.812401; 11.756500; -40.983276;,
    61.710899; 0.000000; -40.983276;,
    74.777596; 11.399002; -40.983276;,
    74.777596; 11.399002; -37.973450;,
    -55.812401; 11.756500; -37.973450;,
    74.777596; 60.682602; -37.973450;,
    -74.777603; 60.682602; -37.973450;,
    61.710899; 0.000000; -37.973450;,
    61.710899; 0.000000; 37.219078;,
    -45.723602; 0.000000; 37.219078;,
    -45.723602; 0.000000; -37.973450;,
    61.710899; 0.000000; 40.983276;,
    74.777596; 11.399002; 40.983276;,
    -45.723602; 0.000000; 40.983276;,
    61.710899; 0.000000; 40.983276;,
    -55.812401; 11.756500; 40.983276;,
    -45.723602; 0.000000; 40.983276;,
    74.777596; 11.399002; -40.983276;,
    61.710899; 0.000000; -40.983276;,
    61.710899; 0.000000; -40.983276;,
    -45.723602; 0.000000; -40.983276;,
    -45.723602; 0.000000; -40.983276;,
    -55.812401; 11.756500; -40.983276;;
    60;
    3;0, 1, 2;,
    3;1, 3, 2;,
    3;4, 5, 6;,
    3;5, 7, 6;,
    3;8, 9, 10;,
    3;9, 11, 10;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;16, 17, 18;,
    3;17, 19, 18;,
    3;20, 21, 22;,
    3;21, 23, 22;,
    3;24, 25, 26;,
    3;25, 27, 26;,
    3;28, 29, 30;,
    3;29, 31, 30;,
    3;32, 1, 33;,
    3;1, 0, 33;,
    3;34, 3, 32;,
    3;3, 1, 32;,
    3;33, 0, 35;,
    3;0, 2, 35;,
    3;35, 2, 34;,
    3;2, 3, 34;,
    3;36, 37, 38;,
    3;37, 39, 38;,
    3;40, 41, 36;,
    3;41, 37, 36;,
    3;38, 39, 42;,
    3;39, 43, 42;,
    3;42, 43, 40;,
    3;43, 41, 40;,
    3;44, 45, 46;,
    3;45, 47, 46;,
    3;48, 49, 50;,
    3;49, 51, 50;,
    3;52, 53, 54;,
    3;53, 55, 54;,
    3;56, 57, 58;,
    3;57, 59, 58;,
    3;60, 14, 61;,
    3;14, 15, 61;,
    3;17, 16, 62;,
    3;16, 63, 62;,
    3;64, 61, 65;,
    3;61, 15, 65;,
    3;66, 7, 67;,
    3;7, 5, 67;,
    3;45, 49, 47;,
    3;49, 48, 47;,
    3;68, 17, 69;,
    3;17, 62, 69;,
    3;70, 14, 71;,
    3;14, 60, 71;,
    3;53, 57, 55;,
    3;57, 56, 55;,
    3;72, 4, 73;,
    3;4, 6, 73;,
    3;74, 63, 75;,
    3;63, 16, 75;;

   MeshNormals {
    76;
    -0.014460; 0.999792; 0.014362;,
    0.005784; 0.999719; 0.022981;,
    -0.005784; 0.999719; -0.022981;,
    0.014460; 0.999792; -0.014362;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    1.000000; 0.000000; 0.000000;,
    0.838027; -0.545629; 0.000000;,
    0.838027; -0.545629; 0.000000;,
    -0.810982; -0.585071; 0.000000;,
    -0.839867; -0.542792; 0.000000;,
    -0.932401; -0.361426; 0.000000;,
    -0.932401; -0.361426; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    -1.000000; 0.000000; 0.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.019281; 0.999631; 0.019151;,
    -0.009640; 0.999220; 0.038301;,
    0.009640; 0.999220; -0.038302;,
    -0.019281; 0.999631; -0.019151;,
    0.009640; -0.999220; 0.038301;,
    0.019281; -0.999631; 0.019151;,
    0.019281; -0.999631; -0.019151;,
    0.009640; -0.999220; -0.038302;,
    -0.019281; -0.999631; 0.019151;,
    -0.009640; -0.999220; 0.038301;,
    -0.009640; -0.999220; -0.038302;,
    -0.019281; -0.999631; -0.019151;,
    0.000000; 0.000000; 1.000000;,
    0.001224; 0.447212; 0.894427;,
    0.000000; 0.000000; 1.000000;,
    0.002449; 0.894424; 0.447214;,
    0.001936; 0.707104; 0.707107;,
    0.001936; 0.707104; 0.707107;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.001224; 0.447212; -0.894427;,
    0.000000; 0.000000; -1.000000;,
    0.002449; 0.894424; -0.447214;,
    0.001936; 0.707104; -0.707107;,
    0.001936; 0.707104; -0.707107;,
    0.000000; 0.000000; -1.000000;,
    0.000000; 0.000000; -1.000000;,
    0.657382; -0.753558; 0.000000;,
    0.657382; -0.753558; 0.000000;,
    -0.758880; -0.651230; 0.000000;,
    -0.758880; -0.651230; 0.000000;,
    0.657382; -0.753558; 0.000000;,
    0.657382; -0.753558; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    -0.758880; -0.651230; 0.000000;,
    -0.758880; -0.651230; 0.000000;,
    0.657382; -0.753558; 0.000000;,
    0.657382; -0.753558; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    0.000000; -1.000000; 0.000000;,
    -0.758880; -0.651230; 0.000000;,
    -0.758880; -0.651230; 0.000000;;
    60;
    3;0, 1, 2;,
    3;1, 3, 2;,
    3;4, 5, 6;,
    3;5, 7, 6;,
    3;8, 9, 10;,
    3;9, 11, 10;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;16, 17, 18;,
    3;17, 19, 18;,
    3;20, 21, 22;,
    3;21, 23, 22;,
    3;24, 25, 26;,
    3;25, 27, 26;,
    3;28, 29, 30;,
    3;29, 31, 30;,
    3;32, 1, 33;,
    3;1, 0, 33;,
    3;34, 3, 32;,
    3;3, 1, 32;,
    3;33, 0, 35;,
    3;0, 2, 35;,
    3;35, 2, 34;,
    3;2, 3, 34;,
    3;36, 37, 38;,
    3;37, 39, 38;,
    3;40, 41, 36;,
    3;41, 37, 36;,
    3;38, 39, 42;,
    3;39, 43, 42;,
    3;42, 43, 40;,
    3;43, 41, 40;,
    3;44, 45, 46;,
    3;45, 47, 46;,
    3;48, 49, 50;,
    3;49, 51, 50;,
    3;52, 53, 54;,
    3;53, 55, 54;,
    3;56, 57, 58;,
    3;57, 59, 58;,
    3;60, 14, 61;,
    3;14, 15, 61;,
    3;17, 16, 62;,
    3;16, 63, 62;,
    3;64, 61, 65;,
    3;61, 15, 65;,
    3;66, 7, 67;,
    3;7, 5, 67;,
    3;45, 49, 47;,
    3;49, 48, 47;,
    3;68, 17, 69;,
    3;17, 62, 69;,
    3;70, 14, 71;,
    3;14, 60, 71;,
    3;53, 57, 55;,
    3;57, 56, 55;,
    3;72, 4, 73;,
    3;4, 6, 73;,
    3;74, 63, 75;,
    3;63, 16, 75;;
   }

   MeshTextureCoords {
    76;
    0.638324; 0.894230;,
    0.638324; 0.486118;,
    0.361242; 0.894230;,
    0.361242; 0.486118;,
    0.714915; 0.097863;,
    0.714915; 0.281361;,
    0.385508; 0.097863;,
    0.385508; 0.281361;,
    0.683052; 0.494278;,
    0.683052; 0.459323;,
    0.320353; 0.494278;,
    0.320353; 0.459323;,
    0.671414; 0.493157;,
    0.331991; 0.493157;,
    0.671414; 0.856756;,
    0.331991; 0.856756;,
    0.671414; 0.854052;,
    0.331991; 0.854052;,
    0.671414; 0.493157;,
    0.331991; 0.493157;,
    0.683052; 0.494278;,
    0.320353; 0.494278;,
    0.683052; 0.459323;,
    0.320353; 0.459323;,
    0.938163; 0.055900;,
    0.058163; 0.055900;,
    0.938163; 0.030163;,
    0.058163; 0.030163;,
    0.058163; 0.055900;,
    0.938163; 0.055900;,
    0.058163; 0.030163;,
    0.938163; 0.030163;,
    0.647825; 0.472124;,
    0.647825; 0.908224;,
    0.351741; 0.472124;,
    0.351741; 0.908224;,
    0.280702; 0.091571;,
    0.296425; 0.097863;,
    0.280702; 0.287653;,
    0.296425; 0.281361;,
    0.770702; 0.091571;,
    0.754979; 0.097863;,
    0.770702; 0.287653;,
    0.754979; 0.281361;,
    0.837974; 0.393020;,
    0.909926; 0.329538;,
    0.246386; 0.393020;,
    0.190832; 0.327547;,
    0.190832; 0.327547;,
    0.909926; 0.329538;,
    0.086400; 0.055074;,
    0.909926; 0.055074;,
    0.246386; 0.393020;,
    0.190832; 0.327547;,
    0.837974; 0.393020;,
    0.909926; 0.329538;,
    0.909926; 0.329538;,
    0.190832; 0.327547;,
    0.909926; 0.055074;,
    0.086400; 0.055074;,
    0.671414; 0.942980;,
    0.331991; 0.942980;,
    0.331991; 0.942980;,
    0.671414; 0.942980;,
    0.314999; 0.942980;,
    0.314999; 0.856756;,
    0.385508; 0.290547;,
    0.714915; 0.290547;,
    0.314999; 0.854052;,
    0.314999; 0.942980;,
    0.685000; 0.856756;,
    0.685000; 0.942980;,
    0.714915; 0.090518;,
    0.385508; 0.090518;,
    0.685000; 0.942980;,
    0.685000; 0.854052;;
   }

   MeshVertexColors {
    76;
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
    75; 1.000000; 1.000000; 1.000000; 1.000000;;
   }

   MeshMaterialList {
    1;
    60;
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

    Material industrial26 {
     0.992157; 0.992157; 0.992157; 1.000000;;
     128.000000;
     0.150000; 0.150000; 0.150000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "industrial26.dds";
     }
    }

   }
  }
}
