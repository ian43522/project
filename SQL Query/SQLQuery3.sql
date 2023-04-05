CREATE TABLE projects (
  id INTEGER PRIMARY KEY identity,
  name nvarchar(100),
  description nvarchar(100),
  start_date DATE,
  end_date DATE,
  budget nvarchar(100)
);

CREATE TABLE employees (
  id INTEGER PRIMARY KEY identity,
  name nvarchar(100),
  position nvarchar(100)
);

CREATE TABLE project_participants (
  id INTEGER PRIMARY KEY identity,
  project_id INTEGER,
  employee_id INTEGER,
  role TEXT,
  FOREIGN KEY (project_id) REFERENCES projects(id),
  FOREIGN KEY (employee_id) REFERENCES employees(id)
);

CREATE TABLE tasks (
  id INTEGER PRIMARY KEY identity,
  project_id INTEGER,
  name TEXT,
  description nvarchar(100),
  start_date DATE,
  end_date DATE,
  status nvarchar(100),
  FOREIGN KEY (project_id) REFERENCES projects(id)
);