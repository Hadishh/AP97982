using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P1
{
    public interface IUserInterface
    {
        UIElement GetUI();
    }
    public interface IDrawable
    {
        void Draw();
    }
}
