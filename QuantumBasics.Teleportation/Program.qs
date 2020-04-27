namespace Quantum.QuantumBasics.Teleportation {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    
    operation Teleportation (sentMessage : Bool) : Bool {
        mutable receivedMessage = false;

        // Default state of Qubit is 0
        using (register = Qubit[3]) {  // a list of Qubits
            let message = register[0]; // Message Qubit

            if (sentMessage) {
                X(message); // Toggle state when successfull
			}	

            let john = register[1]; // Init sender
            let jane = register[2]; // Init receiver 

            // Sequence of messaging entanglement pare
            H(john); // Set to superposition
            CNOT(john, jane); // Entangle sender & receiver 
            CNOT(message, john); // entangle sender with message qubit
            H(message); // Set message to superposition

            // Clasical infomation usually transmitted using other transport mechanism            
            let messageState = M(message);
            let johnState = M(john);

            // NB! The value (2 options) messageSate determines the states (4 options) of the communication content
            if (messageState == One) {
                Z(jane); // 
		    }

            if (johnState == One) {
                X(jane); // Flipts the state of Jane
		    }

            if (M(jane) == One) { // Convert 
                set receivedMessage = true;
		    }

            ResetAll(register); // Reset all the list of Qubits
	    }

        return receivedMessage;
    }
}
