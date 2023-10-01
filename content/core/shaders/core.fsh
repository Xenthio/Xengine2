#version 330 core

in vec2 fUv;
in vec4 fColour;

uniform sampler2D uTexture0;

out vec4 out_color;

void main()
{
    out_color = texture(uTexture0, fUv) * fColour;
    //out_color = vec4(1.0, 0.0, 0.0, 1.0);
}
