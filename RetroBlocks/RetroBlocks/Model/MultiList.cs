using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBlocks.Model
{
    class MultiList
    {
        private List<Block> _blockRow;
        private List<Block> _blockColumn;  
        public MultiList()
        {
            _blockRow = new List<Block>();
            _blockColumn = new List<Block>();

        }

        public MultiList(int height,int width)
        {
            _blockRow = new List<Block>(height+1);
            _blockColumn = new List<Block>(width+1);

            //add blockrows into each column
            _blockColumn.AddRange(_blockRow);
        }


        public List<Block> getList()
        {
            return _blockRow;
        }
    }
}
