SET search_path TO ganimedes;

CREATE TABLE IF NOT EXISTS Usuario(
    nusp VARCHAR(8) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    link_lattes VARCHAR(300) NOT NULL,
    dt_atualizacao_lattes DATE NOT NULL,
    perfil VARCHAR(7) NOT NULL
);

CREATE TABLE IF NOT EXISTS Aluno(
    nusp VARCHAR(8),
    curso VARCHAR(9) NOT NULL,
    ano_ingresso INT NOT NULL,
    exame_proficiencia VARCHAR(13) NOT NULL,
    exame_qualificacao VARCHAR(13) NOT NULL,
    prazo_maximo_qualificacao DATE NOT NULL,
    prazo_maximo_deposito_tese DATE NOT NULL,
    orientador VARCHAR(8) NOT NULL,
    rg VARCHAR(7) NOT NULL,
    dt_nascimento DATE NOT NULL,
    nacionalidade VARCHAR(80) NOT NULL
);

ALTER TABLE Aluno
ADD CONSTRAINT fk_aluno_usuario 
FOREIGN KEY (nusp) REFERENCES Usuario(nusp);

ALTER TABLE Aluno
ADD CONSTRAINT fk_aluno_usuario_orientador 
FOREIGN KEY (orientador) REFERENCES Usuario(nusp);

CREATE TABLE IF NOT EXISTS Disciplinas (
    codigo_disciplina VARCHAR(7) PRIMARY KEY,
    nome_disciplina VARCHAR(80) NOT NULL
);

CREATE TABLE IF NOT EXISTS Disciplinas_cursadas(
    codigo_disciplina VARCHAR(7) NOT NULL,
    nusp_aluno VARCHAR(8) NOT NULL,
    resultado BOOLEAN NOT NULL,
    semestre VARCHAR(7)
);

ALTER TABLE Disciplinas_cursadas
ADD CONSTRAINT fk_codigo_disciplina_Disciplinas_cursadas_Disciplinas 
FOREIGN KEY (codigo_disciplina) REFERENCES Disciplinas(codigo_disciplina);

ALTER TABLE Disciplinas_cursadas
ADD CONSTRAINT fk_nusp_aluno_Disciplinas_cursadas_Usuario 
FOREIGN KEY (nusp_aluno) REFERENCES Usuario(nusp);

CREATE TABLE IF NOT EXISTS Formulario(
    id_parecer INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    nusp_aluno VARCHAR(8) NOT NULL,
    nusp_orientador VARCHAR(8) NOT NULL,
    resultado VARCHAR(22),
    referencia DATE NOT NULL,
    artigos_em_escrita INT NOT NULL,
    artigos_em_avaliacao INT NOT NULL,
    artigos_aceitos INT NOT NULL,
    atividades_academicas VARCHAR(5000) NOT NULL,
    atividades_pesquisa VARCHAR(5000) NOT NULL,
    declaracao_adicional_comissao VARCHAR(1000) NOT NULL,
    dificuldade_apoio_coordenacao BOOLEAN NOT NULL,
    parecer_orientador VARCHAR(1000) NOT NULL,
    parecer_ccp VARCHAR(1000) NOT NULL,
    data_preenchimento DATE NOT NULL
);

ALTER TABLE Formulario
ADD CONSTRAINT fk_nusp_aluno_Formulario_Usuario 
FOREIGN KEY (nusp_aluno) REFERENCES Usuario(nusp);

ALTER TABLE Formulario
ADD CONSTRAINT fk_nusp_orientador_Formulario_Usuario 
FOREIGN KEY (nusp_orientador) REFERENCES Usuario(nusp);

CREATE TABLE IF NOT EXISTS Notificacao(
    descricao VARCHAR(200) NOT NULL,
    visualizada BOOLEAN,
    nusp_destinatario VARCHAR(8) NOT NULL,
    parecer_gerador INT NOT NULL  
);

ALTER TABLE Notificacao
ADD CONSTRAINT fk_nusp_destinatario_Notificacao_Usuario 
FOREIGN KEY (nusp_destinatario) REFERENCES Usuario(nusp);

ALTER TABLE Notificacao
ADD CONSTRAINT fk_parecer_gerador_Notificacao_Formulario 
FOREIGN KEY (parecer_gerador) REFERENCES Formulario(id_parecer);