using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenAI.Chat;

namespace Final_Project
{
	internal static class OpenaiService
	{
		public static int test = 0;
		public static async Task<string> chat(string prompt)
		{
			string responseText;
			// 創建 ChatClient 客戶端
			ChatClient client = new ChatClient(model: "gpt-4o-mini", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

			// 構造聊天消息
			List<ChatMessage> messages = new List<ChatMessage>
			{
				new SystemChatMessage("You are a helpful assistant"),
				ChatMessage.CreateUserMessage(prompt)
			};

			try
			{
				// 調用 Chat API 並獲得回應
				ChatCompletion completion = await client.CompleteChatAsync(messages);

				// 確保回應內容不為空
				if (completion.Content != null && completion.Content.Count > 0)
				{
					responseText = completion.Content[0].Text;
				}
				else
				{
					responseText = "No response from the model.";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
				responseText = "No response from the model.";

			}
			return responseText;
		}

		public static async Task<string> getKeyPoint(string prompt)
		{
			string responseText;

			ChatClient client = new ChatClient(model: "gpt-4o-mini", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
			List<ChatMessage> messages = new List<ChatMessage>
			{
				new SystemChatMessage("你現在熟知地理和google map上的資訊，是個強大的美食推薦助手"),
				ChatMessage.CreateUserMessage("請你對下列 [User Prompt] 做處理，請你回傳一個字串，需要包含幾個資料:" +
											"第一筆資料為該句子要查詢的中心位置;第二筆資料為該句子要查詢的範圍，以公尺為單位，如輸入單位為公里需進行轉換，若未發現該資料則回傳1000;" +
											"剩下的為關鍵詞，像是食物類型(牛排、火鍋等等)，或是特殊需求(素食、無辣等等)，若沒有特別聲明請預設回傳\"餐廳\"" +
											"請注意，輸入的關鍵詞可能會有多個，請以逗號分隔，並且不要有空格，如:牛排,火鍋,素食,無辣" +
											"另外請注意，若整份查詢跟詢問餐廳、美食推薦無關，或者無法解析，請擬將整份回傳的內容設定為 \"無法解析\"" +
											"以下為一個範例: \"[User Prompt] 成功大學附近有什麼好吃的牛排店嗎?\" 根據上述，你需要回答的字串為\"成功大學,1000,牛排\""),
				ChatMessage.CreateUserMessage("[User Prompt]" + prompt)
			};

			try
			{
				// 調用 Chat API 並獲得回應
				ChatCompletion completion = await client.CompleteChatAsync(messages);

				// 確保回應內容不為空
				if (completion.Content != null && completion.Content.Count > 0 && completion.Content[0].Text != "無法解析")
				{
					responseText = completion.Content[0].Text;
				}
				else
				{
					responseText = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
				responseText = null;

			}
			return responseText;

		}

		public static async Task<String> infoSummarize(string input)
		{
			string responseText;

			ChatClient client = new ChatClient(model: "gpt-4o-mini", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
			List<ChatMessage> messages = new List<ChatMessage>
			{
				new SystemChatMessage("你是一個強大AI助手，熟悉繁體中文的文字分析和摘要"),
				new UserChatMessage("請你對下列 [User Prompt] 做處理，請你回傳一個字串，內容為 [User Prompt] 文字內容整理後的內容。" +
									"你需要對其中提到的內容(像是餐廳簡介、評論等等)做摘要整理，並回傳五十到一百字的餐廳或店家的簡介" +
									"若資訊不足無法做摘要或重點整理，請回傳\"資訊不足\""),
				ChatMessage.CreateUserMessage(" [User Prompt]" + input)
			};

			try
			{
				// 調用 Chat API 並獲得回應
				ChatCompletion completion = await client.CompleteChatAsync(messages);

				// 確保回應內容不為空
				if (completion.Content != null && completion.Content.Count > 0)
				{
					responseText = completion.Content[0].Text;
				}
				else
				{
					responseText = "No response from the model.";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
				responseText = "No response from the model.";

			}
			return responseText;
		}
	}
}
