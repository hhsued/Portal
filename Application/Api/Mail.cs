namespace Application.Api.Components
{
	public static class mail
	{
		//  public function send($Subject, $Text, $Receivers, $Attachments = null, $From = array('ter@bezirk-hh-sued.de', 'Internetseite'), $ReplyTo = null)
		//  {
		//    global $app;
		//    require $app->BasePath.'libs/vendor/autoload.php';

		//    $mail = new PHPMailer();     
		//                           // Passing `true` enables exceptions
		//    try {
		//      //Server settings
		//      $mail->SMTPDebug = 1;                                 // Enable verbose debug output
		//      $mail->isSMTP();                                      // Set mailer to use SMTP
		//      $mail->Host = 'w0131afa.kasserver.com';  // Specify main and backup SMTP servers
		//      $mail->SMTPAuth = true;                               // Enable SMTP authentication
		//      $mail->Username = 'm04adf11';                 // SMTP username
		//      $mail->Password = 'Nak123!';                           // SMTP password
		//      $mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also accepted
		//      $mail->Port = 587;                                    // TCP port to connect to

		//      //Recipients
		//      $mail = mail::From($From, $mail);
		//      //$mail->setFrom('ter@bezirk-hh-sued.de', 'Internetseite');
		//      $mail = mail::Receivers($Receivers, $mail);
		//      //$mail->addAddress('kirche@familie-koester.eu', 'Christian Köster');
		//      //$mail->addAddress(' Termine.HH-Sued@menne.biz', 'Jan Menne');     // Add a recipient

		//      $mail = mail::ReplyTo($ReplyTo, $mail);
		//      //$mail->addReplyTo(($larrParameter[1]['Information']['SenderMail'] != '') ? $larrParameter[1]['Information']['SenderMail'] : '', ($larrParameter[1]['Information']['SenderName'] != '') ? $larrParameter[1]['Information']['SenderName'] : '');

		//      //Attachments
		//      $mail = mail::Attachments($Attachments, $mail);
		//      //$mail->addAttachment($lstrFileName);         // Add attachments

		//      //Content
		//      $mail->isHTML(true);                                  // Set email format to HTML
		//      $mail->Subject = $Subject;
		//      $mail->Body = $Text;

		//      $mail->send();
		//      var_dump($mail);
		//      return 'Message has been sent';
		//    } catch (Exception $e) {
		//      return 'Message could not be sent. Mailer Error: ' . $mail->ErrorInfo;
		//    }
		//  }

		//  private function Attachments($Attachments, $Mail)
		//  {
		//    if (is_array($Attachments)) {
		//      foreach ($Attachments as $lstrAttachment) {
		//        $Mail->addAttachment($lstrAttachment);
		//      }
		//    } else {
		//      $Mail->addAttachment($Attachments);
		//    }
		//    return $Mail;
		//  }
		//  private function Receivers($Receivers, $Mail)
		//  {
		//    if (!is_array($Receivers)) {
		//      $Mail->addAddress($Receivers);
		//    } else {
		//      foreach($Receivers as $mixReceiver) {
		//        if (is_Array($mixReceiver)) {
		//          $Mail->addAddress(mail::getMail($mixReceiver), mail::getName($mixReceiver));
		//        } else {
		//          $Mail->addAddress($mixReceiver);
		//        }
		//      }
		//    }
		//    return $Mail;
		//  }
		//  private function From($From, $Mail)
		//  {
		//    if ($From != null && $From != '') {
		//      if (is_array($From)) {
		//        $Mail->setFrom(mail::getMail($From), mail::getName($From));
		//      } else {
		//        $Mail->setFrom($From);
		//      }

		//    }
		//    return $Mail;
		//  }
		//  private function ReplyTo($ReplyTo, $Mail)
		//  { 
		//    if ($ReplyTo != null && $ReplyTo != '') {
		//      $Mail->addReplyTo(mail::getMail($ReplyTo), mail::getName($ReplyTo));
		//    }
		//    return $Mail;
		//  }
		//  private function getMail($Array)
		//  {
		//    if (is_array($Array)) {
		//      return strstr($Array[0], '@') ? $Array[0] : $Array[1];
		//    }
		//  }
		//  private function getName($Array)
		//  {
		//    if (is_array($Array)) {
		//      return strstr($Array[0], '@') ? $Array[1] : $Array[0];
		//    }
		//  }
	}
}