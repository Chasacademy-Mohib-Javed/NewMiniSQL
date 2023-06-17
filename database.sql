CREATE TABLE "public"."Mob_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(20) NOT NULL,
  CONSTRAINT "Mob_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."Mob_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "Mob_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."Mob_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(15) NOT NULL,
  CONSTRAINT "Mob_person_pkey" PRIMARY KEY ("id")
);
ALTER TABLE "public"."Mob_project_person" ADD CONSTRAINT "FK_Mob_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."Mob_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Mob_project_person" ADD CONSTRAINT "FK_Mob_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."Mob_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
