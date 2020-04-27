namespace Quantum.QuantumBasics.Entanglement {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Entanglement () : (Result, Result) {
        
        using ((qubitOne, qubitTwo) = (Qubit(), Qubit())) {
            mutable qubitOneState = Zero;
            mutable qubitTwoState = Zero;            

            H(qubitOne); // Set the first Qubit in superposition
            CNOT(qubitOne, qubitTwo); // Entangle both qubits

            set qubitOneState = M(qubitOne); // Colapse state of qubit one
            set qubitTwoState = M(qubitTwo); // Colapse state of qubit two

            Reset(qubitOne); // All qubits must be reset before releasing
            Reset(qubitTwo); // All qubits must be reset before releasing

            return (qubitOneState, qubitTwoState); // Return the colapsed state for the two qubits
		}
	}
}
