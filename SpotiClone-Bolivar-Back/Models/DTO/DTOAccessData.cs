namespace SpotiClone_Bolivar_Back
{
	public class DTOAccessData
	{
        public required string access_token { get; set; }

        public required string token_type { get; set; }

        public required int expires_in { get; set; }
	}
}

