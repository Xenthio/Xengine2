#version 330 core
layout (location = 0) in vec3 vPosition;
layout (location = 1) in vec2 vUv;
layout (location = 2) in vec4 vColour;

 
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

out vec2 fUv;
out vec4 fColour;

void main()
{
    // note that we read the multiplication from right to left
    gl_Position = projection * view * model * vec4(vPosition, 1.0);
    fUv = vUv;
    fColour = vColour;
}
