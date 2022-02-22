namespace Application.Api.Components
{
	public static class Authorization
	{
		public static string Token;
		public static void SetToken(string token)
		{
			Token = token;
		}
		public static void Check()
		{
			//global $app;
			/*$larrData = $app->DB->execute("SELECT * from sys_sessions WHERE id = '". $this->Token ."'");
	    if (!$larrData) {
	        die($app->t('not_logged_in'));
	    }*/
		}
	}
}