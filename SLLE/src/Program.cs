using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SLLE.util;

namespace SLLE.src
{
    /// <summary> Основной класс программы </summary>
    internal class Program: GameWindow
    {
        // треугольник
        float[] vertives =
        {
            0f, 0.5f, 0f, // верхняя точка
            -0.5f, -0.5f, 0f, // левая точка
            0.5f, -0.5f, 0f // правая точка
        };

        // переменные для рендера
        int vao;
        int shaderProgram;

        // размеры экрана
        int width, height;

        public Program(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.width = width;
            this.height = height;

            // Центрируем наше окно по середине экрана
            this.CenterWindow(new Vector2i(width, height));
        }

        /// <summary> Метод вызываемый при изменении размеров экрана </summary>
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            // переопределяем область окна
            GL.Viewport(0, 0, e.Width, e.Height);

            // переопределяем размеры окна
            this.width = e.Width;
            this.height = e.Height;
        }

        /// <summary> Метод вызываемый при запуске программы </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            vao = GL.GenVertexArray(); // Vertex array Object

            // Vertex buffer Object
            int vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            // Отрисовываем наш треугольник (пока что в буфере) 
            GL.BufferData(BufferTarget.ArrayBuffer, 
                vertives.Length * sizeof(float), 
                vertives, BufferUsageHint.StaticDraw);

            // биндим наш шэйдер Vertex Array Object
            GL.BindVertexArray(vao);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexArrayAttrib(vao, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); // удаляем бинд
            GL.BindVertexArray(0);

            // создаём шейдер
            shaderProgram = GL.CreateProgram();

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, util.ShaderManager.LoadRaw("Default.vert"));
            GL.CompileShader(vertexShader);

            int fragmentSahder = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentSahder, util.ShaderManager.LoadRaw("Default.frag"));
            GL.CompileShader(fragmentSahder);

            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentSahder);

            GL.LinkProgram(shaderProgram);

            // удаляем шейдеры
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentSahder);
        }

        /// <summary> Метод вызываемый при выключении программы </summary>
        protected override void OnUnload()
        {
            base.OnUnload();

            GL.DeleteVertexArray(vao);
            GL.DeleteProgram(shaderProgram);
        }

        /// <summary> Метод вызываемый при рендере </summary>
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // чистим окно
            GL.ClearColor(0, 0, 1f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // рисуем треугольник
            GL.UseProgram(shaderProgram);
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            // обновляем буфер окна
            Context.SwapBuffers();

            base.OnRenderFrame(args);
        }

        /// <summary> Метод вызываемый при обновлении экрана </summary>
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
    }
}
