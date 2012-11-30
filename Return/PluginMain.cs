using System;
using Drawing = System.Drawing;
using Terraria;
using Hooks;
using TShockAPI;
using TShockAPI.DB;

namespace Return
{
    [APIVersion(1, 12)]
    public class Return : TerrariaPlugin
    {    	
        public override Version Version
        {
            get { return new Version("1.0"); }
        }
        public override string Name
        {
            get { return "Return"; }
        }
        public override string Author
        {
            get { return "Ijwu"; }
        }
        public override string Description
        {
            get { return "Return"; }
        }

        public Return(Main game)
            : base(game)
        {
        	
        }
        
        public override void Initialize()
        {
        	GameHooks.Initialize += OnInitialize;

        }
        
        public void OnInitialize()
        {
         	Commands.ChatCommands.Add(new Command(ReturnColor, "return"));
        }
		        
        public static void ReturnColor(CommandArgs args)
        {
        	if (args.Parameters.Count < 2)
        	{
        		args.Player.SendMessage("Incorrect Usage. Please retry the command with the correct usage: /return [color] [message]");
        	}
        	else
        	{
        		string color = args.Parameters[0];
	        	Drawing.Color colorObject = Drawing.Color.FromName(color);
	        	Color textColor = new Color(colorObject.R, colorObject.G, colorObject.B);
	        	args.Player.SendMessage(args.Parameters[1], textColor);
        	}
        }
    }
}