//namespace Application.Api {
//	//// create = Neu und leer
//	//// set = Neu mit Postwerten
//	//// get = Holen mit GET oder POST
//	//// delete = löschen
//	//// update = aktualisieren mit Postwerten
//	//// func = spezielle Funktion aufrufen
//	////
//	//include_once './app/helper/strings.php';
//	//use \app\helper\strings as strings;
	
//	public class Routing
//	{
//	  public Routing()
//	  {
//	  }
//	  private void Directly()
//	  {
//	    if (!isset($_POST['query'])) {
//	      die($app->t('directly_noQuery'));
//	    } else {
//	      return $app->DB->execute($_POST['query']);
//	    }
//	  }
//	  private void Create()
//	  {
//	  }
//	  private void ConfigGet()
//	  {
//	    var lstrQuery = "SELECT * FROM `misc_Configuration` WHERE module='" . $app->Request['module'] . "' AND config_group='" . $app->Request['group'] . "'";
//	    return $app->DB->execute($lstrQuery);
//	  }
//	  private void Get()
//	  {
//	  }

//	  private void Func()
//	  {
//		  $lstrPath = $app->BasePath . 'controller' . DS . $app->Request['controller'] . '.php';
//	    $larrParams = array();

//	    if (isset($app->Request['values'])) {
//	      if (is_object($app->Request['values'])) {
//	        $larrParams = (array) $app->Request['values'];
//	      } else {
//	        $larrParams = $app->Request['values'];
//	      }
//	    }
//	    if (file_exists($lstrPath)) {
//	      include_once $lstrPath;
//	      $lstrClass = '\\controller\\' . $app->Request['controller'];
//	      $reflectionClass = new \ReflectionClass($lstrClass);
//	      if ($reflectionClass->hasMethod($app->Request['method'])) {
//	        $reflectionMethod = new \ReflectionMethod($lstrClass, $app->Request['method']);
//	        if (count($larrParams) > 0) {
//	          return $reflectionMethod->invokeArgs(new $lstrClass(), $larrParams);
//	        } else {
//	          return $reflectionMethod->invoke(new $lstrClass());
//	        }
//	      } else {
//	        return "Unknown method: " . $app->Request['method'];
//	      }
//	    }
//	  }

//	  private void checkController()
//	  {
//	    global $app;
//	    $lstrMethod = "";
//	    $larrData = explode("/", $app->Parameter);
//	    if ($larrData[0] == "") {
//	      $lstrMethod = $larrData[1];
//	      array_splice($larrData, 0, 2);
//	    } else {
//	      $lstrMethod = $larrData[0];
//	      array_splice($larrData, 0, 1);
//	    }

//	    $lstrPath = $app->BasePath . 'controller' . DS . $app->Action . '.php';
//	    $larrParams = array();

//	    if (isset($app->Request['values'])) {
//	      if (is_object($app->Request['values'])) {
//	        $larrParams = (array) $app->Request['values'];
//	      } else {
//	        $larrParams = $app->Request['values'];
//	      }
//	    }
//	    if (count($larrData) > 0) {
//	      foreach ($larrData as $lstrData) {
//	        array_push($larrParams, $lstrData);
//	      }
//	    }

//	    if (file_exists($lstrPath)) {
//	      include_once $lstrPath;
//	      $lstrClass = '\\controller\\' . $app->Action;
//	      $reflectionClass = new \ReflectionClass($lstrClass);
//	      if ($reflectionClass->hasMethod($lstrMethod)) {
//	        $reflectionMethod = new \ReflectionMethod($lstrClass, $lstrMethod);
//	        if (count($larrParams) > 0) {
//	          return $reflectionMethod->invokeArgs(new $lstrClass(), array('data' => $larrParams));
//	        } else {
//	          return $reflectionMethod->invoke(new $lstrClass());
//	        }
//	      } else {
//	        return "Unknown method: " . $lstrMethod;
//	      }
//	    }
//	  }

//	  public void route()
//	  {
//	    global $app;

//	    switch ($app->Action) {
//	      case 'job':
//	        return $this->executeJob();
//	      case 'directly':
//	        return $this->directly();
//	      case 'create':
//	        return $this->create();
//	      case 'set':
//	        return $app->DB->set($app->Request['table'], $app->Request['data']);
//	      case 'get':
//	        return $app->DB->get($app->Request);
//	        return $app->DB->execute($lstrQuery);
//	        return $this->get();
//	      case 'cget':
//	        return $this->config_get();
//	      case 'delete':
//	        return $app->DB->delete($app->Request['table'], $app->Request['id']);
//	        break;
//	      case 'update':
//	        return $this->update($app->Request);
//	      case 'func':
//	        return $this->func();
//	      default:
//	        return $this->checkController();
//	    }

//	    die();
//	  }
//	}
//}