namespace Quantum.QuantumBasics.Superposition {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    
    // A method that return a value
    operation Superposition () : Result {
        mutable state = Zero; // variable used to persist the Qubit result

        using (qubit = Qubit())
        {
            H(qubit); // Set the qubit to superposition
            set state = M(qubit); // Colapse the superposition into a base state

            Reset(qubit);
		}

        return state; // Retun the outcome of the colapsed state
    }
}
