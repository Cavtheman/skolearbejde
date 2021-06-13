import torch
import torch.nn as nn

class LSTM(nn.Module):
    def __init__(self, embedding_size, hidden_size, output_size):
        super(LSTM, self).__init__()
        self.embedding_size = embedding_size
        self.hidden_size = hidden_size
        self.output_size = output_size

        # Defining the base LSTM model
        self.model = nn.LSTM(embedding_size, hidden_size)
        # Defining the linear layer that will output the final prediction, based on the LSTM
        self.linear = nn.Linear(hidden_size, output_size)

    # This function is where the magic happens, and where you can make things complicated
    # This is where you run the data through the model, and make a prediction
    # You can set this up in many different ways, depending on your architecture and needs.
    # For another example (with a different model and data),
    # look at the Colab notebook from the week 18 exercises
    def forward(self, data):
        # Look at the pytorch lstm documentation for an explanation of what each of these outputs are
        # Giving the data to the model, and passing it through to make a prediction
        out, (hn, cn) = self.model(data)
        pred = torch.sigmoid(self.linear(hn))
        # Sometimes you want to also output "out", "hn" and "cn", but here we only care about the linear layer's output

        # Predictions here take the form of a vector of len(labels).
        # Whichever index has the highest value should be used as the prediction
        return pred

    # You can save models for later use
    # This is not a necessary method, but it is useful
    def save(self, filename):
        # Saving the inputs
        args_dict = {
            "embedding_size": self.embedding_size,
            "hidden_size": self.hidden_size,
            "output_size": self.output_size
        }
        torch.save({
            "state_dict": self.state_dict(),
            "args_dict": args_dict
        }, filename)
