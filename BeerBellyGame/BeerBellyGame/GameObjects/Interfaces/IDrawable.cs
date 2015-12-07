using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface IDrawable
    {
        Position Position { get; set; }
        Size Size { get; set; }
        string AvatarUri { get; }
    }
}
