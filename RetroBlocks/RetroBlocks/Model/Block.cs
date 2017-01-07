using System.ComponentModel;

namespace RetroBlocks.Model
{
    public enum BlockType
    {
        [Description("empty")]
        EMPTY,
        [Description("red")]
        RED,
        [Description("blue")]
        BLUE,
        [Description("green")]
        GREEN,
        [Description("lblue")]
        LBLUE,
        [Description("lgreen")]
        LGREEN,
        [Description("pink")]
        PINK,
        [Description("yellow")]
        YELLOW
    }

    public class Block
    {
        public Block()
        {
        }

        public Block(BlockType type, bool isPlaced)
        {
            Type = type;
            IsPlaced = isPlaced;
        }

        public BlockType Type { get; set; }

        public bool IsPlaced { get; set; }
    }
}