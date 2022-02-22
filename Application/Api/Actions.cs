namespace Application.Api
{
	//include_once './app/helper/crypt.php';
	//use \app\helper\crypt as crypt;
	public static class Actions {
	    public static bool Create(dynamic Options, dynamic Expires) {
	        //var lstrActionID = crypt::encryptDateTime() . rand(1,100);

	        //var lstrQuery = "INSERT INTO `misc_actions` (`action_id`, `options`, `expires`) VALUES ('".$lstrActionID."', '".json_encode($Options)."', '".$Expires."')";
	        //app->DB->Execute($lstrQuery);
	        return false;
	    }
	    public static bool Execute(dynamic actionID) {
	        //var lstrQuery = "SELECT * FROM `misc_actions` WHERE action_id = '" . $actionID . "'";
	        //var larrResult = $app->DB->execute($lstrQuery);
	        //var larrOptions = json_decode($larrResult[0]['options']);
	        //var lstrAction = $larrOptions->type;
	        //unset($larrOptions->type);

	        //$_POST['request'] = (array)$larrOptions;

	        return false;
	    }
	}
}