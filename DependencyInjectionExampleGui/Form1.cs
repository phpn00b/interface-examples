using DependencyInjectionExample;
using DependencyInjectionExample.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace DependencyInjectionExampleGui
{
	public partial class Form1 : Form
	{
		private readonly IRepository _repository;
		private List<Client> _clients;
		private List<PhoneNumber> _phones;
 
		private void LoadClients()
		{
			_clients = _repository.FetchAllClients();
		}

		private void LoadPhones()
		{
			_phones = _repository.FetchAllPhoneNumbers();
		}

		private void LoadData()
		{
			LoadClients();
			LoadPhones();

			lboxClient.Items.Clear();
			_clients.ForEach(c => lboxClient.Items.Add(c));
			lboxClient.DisplayMember = "FullName";
			lboxClient.ValueMember = "ClientId";

			lboxPhones.Items.Clear();
			_phones.ForEach(p => lboxPhones.Items.Add(p));
			lboxPhones.DisplayMember = "Number";
			lboxPhones.ValueMember = "PhoneNumberId";

			cbPhoneClients.Items.Clear();
			_clients.ForEach(c => cbPhoneClients.Items.Add(c));
			cbPhoneClients.DisplayMember = "FullName";
			cbPhoneClients.ValueMember = "ClientId";
		}


		public Form1(IRepository repository)
		{
			_repository = repository;
			InitializeComponent();
			LoadData();
		}

		private void btAddClient_Click(object sender, System.EventArgs e)
		{
			if(lboxClient.SelectedIndex < 0)
			{
				var newClient = new Client();
				newClient.FirstName = tbFirstName.Text;
				newClient.LastName = tbLastName.Text;
				_repository.AddClient(newClient);
			}
			else
			{
				var client = _clients[lboxClient.SelectedIndex];
				client.FirstName = tbFirstName.Text;
				client.LastName = tbLastName.Text;
				client.PhoneNumbers = _phones.Where(p => p.ClientId == client.ClientId).ToList();
				_repository.UpdateClient(client);
			}
			LoadData();
		}

		private void btRemoveClient_Click(object sender, System.EventArgs e)
		{
			if(lboxClient.SelectedIndex >= 0)
			{
				_repository.RemoveClient(_clients[lboxClient.SelectedIndex].ClientId);
				lboxClient.SelectedIndex = -1;
				LoadData();
			}
		}

		private void btPhoneDelete_Click(object sender, System.EventArgs e)
		{
			if(lboxPhones.SelectedIndex >= 0){
				_repository.RemoveClient(_phones[lboxPhones.SelectedIndex].PhoneNumberId);
			}
		}

		private void btPhoneCreateUpdate_Click(object sender, System.EventArgs e)
		{
			if (lboxPhones.SelectedIndex < 0)
			{
				var phone = new PhoneNumber();
				phone.Number = tbPhoneNumber.Text;
				phone.Location = tbLocation.Text;
				_repository.AddPhoneNumber(phone);
			}
			else
			{
				var phone = _phones[lboxPhones.SelectedIndex];
				phone.Number = tbPhoneNumber.Text;
				phone.Location = tbLocation.Text;
				_repository.RemovePhoneNumber(phone.PhoneNumberId);
			}
			LoadData();
		}

		private void lboxClient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lboxClient.SelectedIndex >= 0)
			{
				var client = _clients[lboxClient.SelectedIndex];
				lbClientId.Text = client.ClientId.ToString();
				tbFirstName.Text = client.FirstName;
				tbLastName.Text = client.LastName;
			}
			else
			{
				lbClientId.Text = "N/A";
				tbFirstName.Text = string.Empty;
				tbLastName.Text = string.Empty;
			}
		}

		private void lboxPhones_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lboxPhones.SelectedIndex >= 0)
			{
				var phone = _phones[lboxPhones.SelectedIndex];
				lbPhoneId.Text = phone.PhoneNumberId.ToString();
				lbPhoneClientId.Text = phone.ClientId.ToString();
				tbPhoneNumber.Text = phone.Number;
				tbLocation.Text = phone.Location;

				if(lboxPhones.SelectedIndex >= 0)
				{
					cbPhoneClients.SelectedIndex = _clients.IndexOf(_clients.Find(c => c.ClientId == phone.ClientId));
				}
				else
				{
					cbPhoneClients.SelectedIndex = -1;
				}
			}
			else
			{
				lbPhoneId.Text = "N/A";
				lbPhoneClientId.Text = "N/A";
				tbPhoneNumber.Text = string.Empty;
				tbLocation.Text = string.Empty;
			}
		}

		private void btResetSelectedClient_Click(object sender, System.EventArgs e)
		{
			lboxClient.SelectedIndex = -1;
		}

		private void btResetSelectionPhones_Click(object sender, System.EventArgs e)
		{
			lboxPhones.SelectedIndex = -1;
		}

		private void tcMain_Selected(object sender, TabControlEventArgs e)
		{
			LoadData();
		}

		private void lbClientId_Click(object sender, System.EventArgs e)
		{

		}
	}
}
