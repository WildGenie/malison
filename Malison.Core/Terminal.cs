using System;
using System.Collections.Generic;
using System.Text;

using Bramble.Core;

namespace Malison.Core
{
    public class Terminal : TerminalBase
    {
        public override Vec Size { get { return mCharacters.Size; } }

        public Terminal(int width, int height)
            : base()
        {
            mCharacters = new Array2D<Character>(width, height);

            // fill with empty characters since default Character constructor doesn't initialize colors
            mCharacters.Fill(new Character(' '));
        }

        protected override Character GetValueCore(Vec pos)
        {
            return mCharacters[pos];
        }

        protected override bool SetValueCore(Vec pos, Character value)
        {
            // don't do anything if the value doesn't change
            if (mCharacters[pos].Equals(value)) return false;

            mCharacters[pos] = value;
            return true;
        }

        internal override ITerminal CreateWindowCore(TermColor foreColor, TermColor backColor, Rect bounds)
        {
            return new WindowTerminal(this, foreColor, backColor, bounds);
        }

        private readonly Array2D<Character> mCharacters;
    }
}
