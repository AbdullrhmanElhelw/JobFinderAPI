namespace Application.Templates
{
    public class EmailRegistrationTemplate
    {
        public static string GetEmailRegistrationTemplate(string email, string token, string origin)
        {
            // Replace the following with your actual email template content
            string template = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                line-height: 1.6;
                                margin: 0;
                                padding: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 20px auto;
                            }}
                            .message {{
                                background-color: #f4f4f4;
                                padding: 20px;
                                border-radius: 10px;
                            }}
                            .button {{
                                background-color: #4caf50;
                                color: white;
                                padding: 10px 20px;
                                text-decoration: none;
                                display: inline-block;
                                border-radius: 5px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='message'>
                                <p>Dear user,</p>
                                <p>Thank you for registering with us! Please click the following link to activate your account:</p>
                                <a class='button' href='{origin}/activate?token={token}&email={email}'>Activate Account</a>
                                <p>If you didn't request this, please ignore this email.</p>
                                <p>Best regards,<br/>Job Finder</p>
                                <p>{token}</p>
                            </div>
                        </div>
                    </body>
                </html>";

            return template;
        }
    }
}