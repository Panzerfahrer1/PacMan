using PacMan.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Pacman
{
    public static class GameRenderer
    {

        public static Panel CreatePanel(int x, int y, Color backColor, Image? image = null)
        {
            var panel = new Panel
            {
                Name = $"panel_{x}_{y}",
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = backColor,
                BackgroundImage = image
            };

            return panel;
        }

        public static PictureBox CreatePictureBox(int x, int y, Image? image = null)
        {
            var pictureBox = new PictureBox
            {
                Name = $"pictureBox_{x}_{y}",
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = Color.Transparent,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            return pictureBox;
        }
    }
}
