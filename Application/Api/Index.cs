//namespace Application.Api
//{
//	public static class Index
//	{
//		public static string BasePath;
//		public static string BaseURL;
//		public static string RequestMethod;
//		public static string Action;
//		//public static $Parameter;

//		//public static $Request;
//		//public static $Data;
//		public static void Api(string url, string[] post)
//		{
//			//header('Content-type: text/html; charset=utf-8');
//			//define('DS', DIRECTORY_SEPARATOR);

//			//// $_POST['query'] = 'SELECT * FROM  `add_Contact` LIMIT 0 , 30';
//			//if ($_SERVER['REQUEST_METHOD'] === 'POST' && empty($_POST)) {
//			//	$_POST = json_decode(file_get_contents('php://input'), true);
//			//}

//			//if (isset($_POST['query']))
//			//{
//			//	include_once './sql.php';
//			//}
//			//else
//			//{
//			//	include_once './api.php';
//			//}
//		}

//		public static void Setup(string AuthToken = "")
//		{
//			/*if ($AuthToken == "") {
//				die(this.t('no_acc_param'));
//			}*/
//			URLs();
//			this.Auth.SetToken(AuthToken);
//		}
//		public static string t(string translationString)
//		{
//			return this.Translation.Translate(translationString);
//		}
//		public static void RouteRequest()
//		{
//			return this.Router.Route();
//		}
//		private void GetAction()
//		{
//			this.Action = str_replace(this.BaseURL, "", $_SERVER['REQUEST_URI']);
//			if (strstr(this.Action, 'index.php')) this.Action = str_replace('index.php', "", this.Action);
//			if (strlen(this.Action) == 0)
//			{
//				die(this.t('no_action'));
//			}
//			else
//			{
//				if (strstr(this.Action, '?'))
//				{
//					if (isset($_GET['action']))
//					{
//						this.Action = actions::execute($_GET['action']);
//					}
//					this.Action = substr(this.Action, 0, strpos(this.Action, '?'));
//				}
//				this.Action = str_replace(strtolower(this.BaseURL), "", strtolower(this.Action));
//				if (substr(this.Action, 0, 1) == '/')
//				{
//					this.Action = substr(this.Action, 1);
//				}

//				if (strpos(this.Action, '/') > 0)
//				{
//					this.Parameter = strstr(this.Action, '/');
//					this.Action = str_replace(this.Parameter, "", this.Action);
//				}
//				if (isset($_POST['request']))
//				{
//					this.Request = $_POST['request'];
//					this.Data = array();
//					if (isset($_POST['data']))
//					{
//						this.Data = $_POST['data'];
//					}
//				}
//				if (isset($_POST))
//				{
//					this.Request['values'] = $_POST;
//				}
//			}
//		}
//		private void URLs()
//		{
//			this.RequestMethod = $_SERVER['REQUEST_METHOD'];
//			this.BasePath = (strstr($_SERVER['SCRIPT_FILENAME'], 'index.php')) ? str_replace('index.php', "", $_SERVER['SCRIPT_FILENAME']) : $_SERVER['SCRIPT_FILENAME'];
//			this.BaseURL = (strstr($_SERVER['SCRIPT_NAME'], 'index.php')) ? str_replace('index.php', "", $_SERVER['SCRIPT_NAME']) : $_SERVER['SCRIPT_NAME'];
//			this.GetAction();
//		}
//	}
//}