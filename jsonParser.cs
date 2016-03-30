        public void OrderJson()
        {
            String log = string.Empty;

            SqlConnection conn = new SqlConnection("user id=user;data source=db;persist security info=True;initial catalog=dbInstance;password=password");
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetOrdersJson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataAdapter sqlDA2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                sqlDA2.Fill(dt2);

                String SerNum = dt2.Rows[0]["result"].ToString();

                log += "{" + Environment.NewLine;
                log += @"""name"": ""Open Orders Last 7 Days""," + Environment.NewLine;
                log += @"""children"": [" + Environment.NewLine;
                log += "{" + Environment.NewLine;


                String[] values = new String[4];
                String[] temp = new String[4];
                int i = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    values = dr[0].ToString().Split(':');

                    if(i == 0)
                    {
                        log += @"""name"": """ + values[0] + @"""," + Environment.NewLine;
                        log += @"""children"": [" + Environment.NewLine;

                        log += "{" + Environment.NewLine;
                        log += @"""name"": """ + values[1] + @"""," + Environment.NewLine;
                        log += @"""children"": [" + Environment.NewLine;

                        log += "{" + Environment.NewLine;
                        log += @"""name"": """ + values[2] + @"""," + Environment.NewLine;
                        log += @"""size"": 1" + Environment.NewLine;
                    }

                    else if(values[0] == temp[0])
                    {
                        if(values[1] == temp[1])
                        {
                            log += "}," + Environment.NewLine;

                            log += "{" + Environment.NewLine;
                            log += @"""name"": """ + values[2] + @"""," + Environment.NewLine;
                            log += @"""size"": 1" + Environment.NewLine;
                        }
                        else
                        {
                            log += "}" + Environment.NewLine;
                            log += "]" + Environment.NewLine;
                            log += "}," + Environment.NewLine;

                            log += "{" + Environment.NewLine;
                            log += @"""name"": """ + values[1] + @"""," + Environment.NewLine;
                            log += @"""children"": [" + Environment.NewLine;

                            log += "{" + Environment.NewLine;
                            log += @"""name"": """ + values[2] + @"""," + Environment.NewLine;
                            log += @"""size"": 1" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        log += "}" + Environment.NewLine;
                        log += "]" + Environment.NewLine;
                        log += "}" + Environment.NewLine;
                        log += "]" + Environment.NewLine;
                        log += "}," + Environment.NewLine;

                        log += "{" + Environment.NewLine;

                        log += @"""name"": """ + values[0] + @"""," + Environment.NewLine;
                        log += @"""children"": [" + Environment.NewLine;

                        log += "{" + Environment.NewLine;
                        log += @"""name"": """ + values[1] + @"""," + Environment.NewLine;
                        log += @"""children"": [" + Environment.NewLine;

                        log += "{" + Environment.NewLine;
                        log += @"""name"": """ + values[2] + @"""," + Environment.NewLine;
                        log += @"""size"": 1" + Environment.NewLine;
                    }
                    i++;
                    temp = values;
                }

                log += "}" + Environment.NewLine;
                log += "]" + Environment.NewLine;
                log += "}" + Environment.NewLine;
                log += "]" + Environment.NewLine;
                log += "}" + Environment.NewLine;
                log += "]" + Environment.NewLine;
                log += "}" + Environment.NewLine;

                File.WriteAllText(Directory.GetCurrentDirectory() + @"\" + "Orders.json", log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }