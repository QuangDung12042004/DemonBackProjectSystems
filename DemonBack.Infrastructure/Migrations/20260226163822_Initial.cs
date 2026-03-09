using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemonBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anime_paths",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    character_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime_paths", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    muscle_group = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    anime_icon_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    current_weight_kg = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    goal = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    preferred_unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    avatar_url = table.Column<string>(type: "text", nullable: true),
                    current_level = table.Column<int>(type: "integer", nullable: false),
                    current_exp = table.Column<int>(type: "integer", nullable: false),
                    rank_title = table.Column<string>(type: "text", nullable: false),
                    streak_days = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "path_exercises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_of_week = table.Column<short>(type: "smallint", nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    recommended_sets = table.Column<int>(type: "integer", nullable: true),
                    recommended_reps = table.Column<int>(type: "integer", nullable: true),
                    rest_seconds = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_path_exercises", x => x.id);
                    table.ForeignKey(
                        name: "FK_path_exercises_anime_paths_path_id",
                        column: x => x.path_id,
                        principalTable: "anime_paths",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_path_exercises_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "body_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    logged_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    weight_kg = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    muscle_mass_kg = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    body_fat_percent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    chest_size = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    waist_size = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    arm_size = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    photo_front_url = table.Column<string>(type: "text", nullable: true),
                    photo_back_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_body_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_body_logs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_path_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    started_at = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_plans", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_plans_anime_paths_source_path_id",
                        column: x => x.source_path_id,
                        principalTable: "anime_paths",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_plans_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_plan_days",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_of_week = table.Column<short>(type: "smallint", nullable: false),
                    notify_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_plan_days", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_plan_days_user_plans_user_plan_id",
                        column: x => x.user_plan_id,
                        principalTable: "user_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_plan_day_exercises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_plan_day_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    target_sets = table.Column<int>(type: "integer", nullable: true),
                    target_reps = table.Column<int>(type: "integer", nullable: true),
                    target_rpe = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: true),
                    rest_seconds = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_plan_day_exercises", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_plan_day_exercises_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_plan_day_exercises_user_plan_days_user_plan_day_id",
                        column: x => x.user_plan_day_id,
                        principalTable: "user_plan_days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout_schedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_plan_day_id = table.Column<Guid>(type: "uuid", nullable: true),
                    scheduled_date = table.Column<DateOnly>(type: "date", nullable: false),
                    scheduled_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    parent_schedule_id = table.Column<Guid>(type: "uuid", nullable: true),
                    suggestion_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout_schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_workout_schedules_user_plan_days_user_plan_day_id",
                        column: x => x.user_plan_day_id,
                        principalTable: "user_plan_days",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_workout_schedules_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_schedules_workout_schedules_parent_schedule_id",
                        column: x => x.parent_schedule_id,
                        principalTable: "workout_schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workout_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_id = table.Column<Guid>(type: "uuid", nullable: true),
                    started_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    ended_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    mood_score = table.Column<short>(type: "smallint", nullable: true),
                    fatigue_score = table.Column<short>(type: "smallint", nullable: true),
                    sleep_hours = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: true),
                    session_rpe = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_workout_sessions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_sessions_workout_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "workout_schedules",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workout_session_exercises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout_session_exercises", x => x.id);
                    table.ForeignKey(
                        name: "FK_workout_session_exercises_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_session_exercises_workout_sessions_session_id",
                        column: x => x.session_id,
                        principalTable: "workout_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout_sets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    set_number = table.Column<int>(type: "integer", nullable: false),
                    weight_kg = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    reps = table.Column<int>(type: "integer", nullable: false),
                    rpe = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: true),
                    is_warmup = table.Column<bool>(type: "boolean", nullable: false),
                    is_pr = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout_sets", x => x.id);
                    table.ForeignKey(
                        name: "FK_workout_sets_workout_session_exercises_session_exercise_id",
                        column: x => x.session_exercise_id,
                        principalTable: "workout_session_exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_body_logs_user_id_logged_at",
                table: "body_logs",
                columns: new[] { "user_id", "logged_at" });

            migrationBuilder.CreateIndex(
                name: "IX_path_exercises_exercise_id",
                table: "path_exercises",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_path_exercises_path_id_day_of_week_order_index",
                table: "path_exercises",
                columns: new[] { "path_id", "day_of_week", "order_index" });

            migrationBuilder.CreateIndex(
                name: "IX_user_plan_day_exercises_exercise_id",
                table: "user_plan_day_exercises",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_plan_day_exercises_user_plan_day_id_order_index",
                table: "user_plan_day_exercises",
                columns: new[] { "user_plan_day_id", "order_index" });

            migrationBuilder.CreateIndex(
                name: "IX_user_plan_days_user_plan_id_day_of_week",
                table: "user_plan_days",
                columns: new[] { "user_plan_id", "day_of_week" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_plans_source_path_id",
                table: "user_plans",
                column: "source_path_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_plans_user_id_is_active",
                table: "user_plans",
                columns: new[] { "user_id", "is_active" });

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_workout_schedules_parent_schedule_id",
                table: "workout_schedules",
                column: "parent_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_schedules_user_id_scheduled_date",
                table: "workout_schedules",
                columns: new[] { "user_id", "scheduled_date" });

            migrationBuilder.CreateIndex(
                name: "IX_workout_schedules_user_id_status",
                table: "workout_schedules",
                columns: new[] { "user_id", "status" });

            migrationBuilder.CreateIndex(
                name: "IX_workout_schedules_user_plan_day_id",
                table: "workout_schedules",
                column: "user_plan_day_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_session_exercises_exercise_id",
                table: "workout_session_exercises",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_session_exercises_session_id_order_index",
                table: "workout_session_exercises",
                columns: new[] { "session_id", "order_index" });

            migrationBuilder.CreateIndex(
                name: "IX_workout_sessions_schedule_id",
                table: "workout_sessions",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_sessions_user_id_started_at",
                table: "workout_sessions",
                columns: new[] { "user_id", "started_at" });

            migrationBuilder.CreateIndex(
                name: "IX_workout_sets_session_exercise_id_set_number",
                table: "workout_sets",
                columns: new[] { "session_exercise_id", "set_number" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "body_logs");

            migrationBuilder.DropTable(
                name: "path_exercises");

            migrationBuilder.DropTable(
                name: "user_plan_day_exercises");

            migrationBuilder.DropTable(
                name: "workout_sets");

            migrationBuilder.DropTable(
                name: "workout_session_exercises");

            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropTable(
                name: "workout_sessions");

            migrationBuilder.DropTable(
                name: "workout_schedules");

            migrationBuilder.DropTable(
                name: "user_plan_days");

            migrationBuilder.DropTable(
                name: "user_plans");

            migrationBuilder.DropTable(
                name: "anime_paths");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
