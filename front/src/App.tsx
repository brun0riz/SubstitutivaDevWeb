import React from "react";
import ListarIMC from "./components/listar-imc";
import ListarImcPorAluno from "./components/listar-imc-aluno";
import CadastrarIMC from "./components/cadastrar-imc";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import AlterarIMC from "./components/alterar-imc";


function App() {
  return (
    <div id="app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>

            <li>
              <Link to="/pages/imc/listar">Listar IMC</Link>
            </li>
            <li>
              <Link to="/pages/imc/listarporaluno">Listar IMC por aluno</Link>
            </li>
            <li>
              <Link to="/pages/imc/cadastrar">Cadastrar IMC</Link>
            </li>
            <li>
              <Link to="/pages/aluno/cadastrar">Cadastrar aluno</Link>
            </li>
            <li>
              <Link to="/pages/imc/alterar">Alterar IMC IMC</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<ListarIMC />}/>
          <Route path="/pages/imc/listar" element={<ListarIMC />}/>
          <Route path="/pages/imc/listarporaluno" element={<ListarImcPorAluno />}/>
          <Route path="/pages/imc/cadastrar" element={<CadastrarIMC />}/>
          <Route path="/pages/aluno/cadastrar" element={<ListarIMC />}/>
          <Route path="/pages/imc/alterar" element={<AlterarIMC />}/>
        </Routes>
      </BrowserRouter>
      
    </div>
  );
}

export default App;
