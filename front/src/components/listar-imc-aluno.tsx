import { useEffect, useState } from "react";
import { IMC } from "../models/imc"


function ListarImcPorAluno()
{
    const [imcs, setIMC] = useState<IMC[]>([]);
    
    useEffect(() =>{
        carregarIMC();
    }, []);

    
    function carregarIMC() {
        fetch(`http://localhost:5250/api/icm/listarporaluno/id`)
        .then((resposta) => resposta.json())
        .then((imcs : IMC[]) =>{
            console.table(imcs);
            setIMC(imcs);
        })
    }
    return (
        <div>
            <h1>Listar IMC</h1>
            <table border={1}>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Sobrenome</th>
                        <th>Altura</th>
                        <th>Peso</th>
                        <th>IMC</th>
                        <th>Classificação</th>
                        <th>Data da criação</th>
                    </tr>
                </thead>
                <tbody>
                    {imcs.map((imc) => (
                        <tr key={imc.imcId}>
                            <td>{imc.aluno?.nome}</td>
                            <td>{imc.aluno?.sobrenome}</td>
                            <td>{imc.altura}</td>
                            <td>{imc.peso}</td>
                            <td>{imc.classificacao}</td>
                            <td>{imc.criadoEm}</td>
                        </tr>                           
                    ))}
                </tbody>
            </table>
        </div>
    )
}
export default ListarImcPorAluno;