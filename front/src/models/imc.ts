import { Aluno } from "./aluno"

export interface IMC{
    imcId? : string,
    peso : number,
    altura? : number,
    criadoEm? : string,
    classificacao : string,
    aluno? : Aluno, 
    alunoId : string
}
export default IMC;