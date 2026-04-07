using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace SLLE.src
{
    /// <summary> Основной класс программы </summary>
    internal class Program: GameWindow
    {
        // КОНСТАНТЫ

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
        }

        /// <summary> Метод вызываемый при выключении программы </summary>
        protected override void OnUnload()
        {
            base.OnUnload();
        }

        /// <summary> Метод вызываемый при рендере </summary>
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            // чистим окно
            GL.ClearColor(0, 0, 1f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

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
