using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;
using System.Drawing;
using System.IO;

public class Cube
{
    private Vector3[] vertices;
    private Color[] faceColors;
    private Random random;

    public Cube()
    {
        vertices = Vertex("coordonate.txt"); 
        faceColors = new Color[6]; //array cu 6 culori pentru fiecare fata
        random = new Random();
        SetRandomColors(); // culori aleatorii fiecarei fete
    }

    private Vector3[] Vertex(string path)
    {
        Vector3[] loadedVertices = new Vector3[8]; //pt a stoca coordonatele varfurilor


            string[] lines = File.ReadAllLines(path);
            int index = 0;

            foreach (string line in lines) // fiecare linie din fisier.
        {

                string[] coords = line.Split(',');
                if (coords.Length == 3 && index < loadedVertices.Length)
                {
                    float x = float.Parse(coords[0].Trim());
                    float y = float.Parse(coords[1].Trim());
                    float z = float.Parse(coords[2].Trim());
                    loadedVertices[index++] = new Vector3(x, y, z);
                }
            }
        
        

        return loadedVertices;
    }

    public void SetFaceColor(int faceIndex, Color color)
    {
        if (faceIndex >= 0 && faceIndex < faceColors.Length) 
            faceColors[faceIndex] = color;
    }

    public void SetRandomColors()  // setare culoare pt o fata
    {
        for (int i = 0; i < faceColors.Length; i++) // parcurge fiecare fata a cubului
        {
            faceColors[i] = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
        }
    }

    public void Draw()
    {
        GL.Begin(PrimitiveType.Quads);

        for (int i = 0; i < faceColors.Length; i++)
        {
            GL.Color4(faceColors[i]);

            switch (i)
            {
                case 0: // fata 1
                    GL.Vertex3(vertices[0]);
                    GL.Vertex3(vertices[1]);
                    GL.Vertex3(vertices[2]);
                    GL.Vertex3(vertices[3]);
                    break;
                case 1: // fata 2
                    GL.Vertex3(vertices[4]);
                    GL.Vertex3(vertices[5]);
                    GL.Vertex3(vertices[6]);
                    GL.Vertex3(vertices[7]);
                    break;
                case 2: // fata 3
                    GL.Vertex3(vertices[0]);
                    GL.Vertex3(vertices[1]);
                    GL.Vertex3(vertices[5]);
                    GL.Vertex3(vertices[4]);
                    break;
                case 3: // fata 4
                    GL.Vertex3(vertices[2]);
                    GL.Vertex3(vertices[3]);
                    GL.Vertex3(vertices[7]);
                    GL.Vertex3(vertices[6]);
                    break;
                case 4: // fata 5
                    GL.Vertex3(vertices[0]);
                    GL.Vertex3(vertices[3]);
                    GL.Vertex3(vertices[7]);
                    GL.Vertex3(vertices[4]);
                    break;
                case 5: // fata 6
                    GL.Vertex3(vertices[1]);
                    GL.Vertex3(vertices[2]);
                    GL.Vertex3(vertices[6]);
                    GL.Vertex3(vertices[5]);
                    break;
            }
        }

        GL.End();
    }
}
