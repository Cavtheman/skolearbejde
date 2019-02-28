CREATE DATABASE fakenews;

CREATE TABLE Keyword (
  keyword_id serial,
  value varchar(32),
  PRIMARY KEY (keyword_id)
);

CREATE TABLE Author (
  author_id serial,
  author_name varchar(64),
  PRIMARY KEY (author_id)
);

CREATE TABLE Tyme (
  time_id serial,
  time timestamp,
  PRIMARY KEY (time_id)
);

CREATE TABLE Domain (
  domain_id serial,
  domain_url varchar(1024),
  PRIMARY KEY (domain_id)
);

CREATE TABLE Article (
  article_id integer,
  title varchar (512),
  content text,
  summary text,
  created_at integer REFERENCES Tyme(time_id),
  updated_at integer REFERENCES Tyme(time_id),
  scrapped_at integer REFERENCES Tyme(time_id),
  PRIMARY KEY (article_id)
);

CREATE TABLE Webpage (
  web_url varchar(1024),
  article_id integer REFERENCES Article(article_id),
  domain_id integer REFERENCES Domain(domain_id)
);

CREATE TABLE Typ (
  type_id serial,
  name varchar(64),
  article_id integer REFERENCES Article(article_id)
);

CREATE TABLE tags (
  article_id integer REFERENCES Article(article_id),
  keyword_id integer REFERENCES Keyword(keyword_id)
);

CREATE TABLE written_by (
  article_id integer REFERENCES Article(article_id),
  author_id integer REFERENCES Author(author_id)
);
