namespace MyLangParser
{
    public class SyntaxError
    {
        public int Line;
        public int StartPos;
        public int EndPos;
        public int AbsoluteIndex;
        public string Message = "";
        public string Value = "";
        public SyntaxError(int line, int start_pos, int end_pos, int abs_index, string message, string value)
        {
            Line = line;
            StartPos = start_pos;
            EndPos = end_pos;
            AbsoluteIndex = abs_index;
            Message = message;
            Value = value;
        }
    }
}
